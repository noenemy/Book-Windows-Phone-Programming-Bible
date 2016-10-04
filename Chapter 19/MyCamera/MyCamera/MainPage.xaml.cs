using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using Microsoft.Devices;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;


namespace MyCamera
{
    public partial class MainPage : PhoneApplicationPage
    {
        PhotoCamera myCam = new PhotoCamera();

        bool bFocus = false; // 포커스가 잡혔는지 여부
        int currentResIndex = 0; // 현재 설정된 해상도에 대한 인덱스 값

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            myCam = new Microsoft.Devices.PhotoCamera();

            // 카메라 초기화 완료 이벤트 핸들러 등록
            myCam.Initialized += myCam_Initialized;

            // 카메라의 AF(자동포커스) 완료 이벤트 핸들러 등록
            myCam.AutoFocusCompleted += myCam_AutoFocusCompleted;

            // 촬영된 이미지에 접근 가능 이벤트 핸들러 등록
            myCam.CaptureImageAvailable += myCam_CaptureImageAvailable;

            // 사진 촬영 완료 이벤트 핸들러 등록
            myCam.CaptureCompleted += myCam_CaptureCompleted;
            
            // 하드웨어 카메라 버튼에 대한 이벤트 핸들러 등록
            CameraButtons.ShutterKeyHalfPressed += CameraButtons_ShutterKeyHalfPressed;
            CameraButtons.ShutterKeyPressed += CameraButtons_ShutterKeyPressed;
            CameraButtons.ShutterKeyReleased += CameraButtons_ShutterKeyReleased;

            // VideoBrush에 대한 소스를 카메라로 설정
            cameraBrush.SetSource(myCam);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // 카메라에서 사용한 자원 해제
            myCam.Dispose();
        }

        void myCam_AutoFocusCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            bFocus = true;
            Dispatcher.BeginInvoke(delegate()
            {
                txtMessage.Text = "포커스를 설정했습니다.";
            });
        }
        
        void myCam_CaptureImageAvailable(object sender, ContentReadyEventArgs e)
        {
            string fileName = "myCam.jpg";

            // 미디어 라이브러리에 사진 저장하기
            MediaLibrary library = new MediaLibrary();
            library.SavePicture(fileName, e.ImageStream);            
        }

        void myCam_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                txtMessage.Text = "사진을 저장했습니다.";
            });
            bFocus = false;
        }

        void myCam_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                if (e.Succeeded == true)
                    txtMessage.Text = "카메라가 초기화 되었습니다.";
                else
                    txtMessage.Text = "카메라 초기화에 실패하였습니다. " + e.Exception.Message;
            });
        }

        private void btnShutter_Click(object sender, RoutedEventArgs e)
        {
            if (bFocus == true)
            {
                txtMessage.Text = "사진 촬영 중입니다...";
                myCam.CaptureImage();
            }
            else
            {
                txtMessage.Text = "";
            }
        }

        private void btnShutter_Hold(object sender, GestureEventArgs e)
        {
            bFocus = false;
            txtMessage.Text = "포커스를 설정합니다...";
            
            myCam.Focus();
        }

        private void ChangeFlashMode(FlashMode currentFlashMode)
        {
            FlashMode newFlashMode = FlashMode.Auto;
            switch (currentFlashMode)
            {
                case FlashMode.Auto:
                    newFlashMode = FlashMode.Off;
                    break;
                case FlashMode.Off:
                    newFlashMode = FlashMode.On;
                    break;
                case FlashMode.On:
                    newFlashMode = FlashMode.RedEyeReduction;
                    break;
                case FlashMode.RedEyeReduction:
                    newFlashMode = FlashMode.Auto;
                    break;
            }

            // 플래시 모드 변경하기
            // 만약 지원하지 않는 플래시모드이면 다른 모드로 변경한다.
            if (myCam.IsFlashModeSupported(newFlashMode) == false)
                ChangeFlashMode(newFlashMode);
            else
                myCam.FlashMode = newFlashMode;

            txtMessage.Text = "플래시 모드를 '" + myCam.FlashMode.ToString() + "'으로 변경했습니다.";
            btnFlash.Content = myCam.FlashMode.ToString();
        }

        private void btnFlash_Click(object sender, RoutedEventArgs e)
        {
            ChangeFlashMode(myCam.FlashMode);
        }

        private void btnResolution_Click(object sender, RoutedEventArgs e)
        {
            // 현재 카메라에서 지원하는 해상도 목록 가져오기
            IEnumerable<Size> resList = myCam.AvailableResolutions;
            int size = resList.Count<Size>();
            Size res;
            for (int i = 0; i < size; i++)
            {
                res = resList.ElementAt<Size>(i);
            }

            // 해상도 변경하기
            currentResIndex = (currentResIndex + 1) % size;
            res = resList.ElementAt<Size>(currentResIndex);
            myCam.Resolution = res;

            txtMessage.Text = String.Format("해상도를 {0}x{1}로 변경했습니다.", res.Width, res.Height);
            btnResolution.Content = (currentResIndex + 1).ToString();
        }

        private void btnOverlay_Click(object sender, RoutedEventArgs e)
        {
            if (canvasOverlay.Visibility == System.Windows.Visibility.Collapsed)
            {
                canvasOverlay.Visibility = System.Windows.Visibility.Visible;
                btnOverlay.Content = "On";
            }
            else
            {
                canvasOverlay.Visibility = System.Windows.Visibility.Collapsed;
                btnOverlay.Content = "Off";
            }
        }

        void CameraButtons_ShutterKeyReleased(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            myCam.CancelFocus();

            bFocus = false;
        }

        void CameraButtons_ShutterKeyPressed(object sender, EventArgs e)
        {
            if (bFocus == true)
            {
                txtMessage.Text = "사진 촬영 중입니다...";
                myCam.CaptureImage();
            }
            else
            {
                txtMessage.Text = "";
            }
        }

        void CameraButtons_ShutterKeyHalfPressed(object sender, EventArgs e)
        {
            bFocus = false;

            txtMessage.Text = "포커스를 설정합니다...";
            myCam.Focus();
        }
        
    }
}