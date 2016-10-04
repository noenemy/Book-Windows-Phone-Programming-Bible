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
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;
using System.IO;

namespace PhotoExtra
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string strFileId = "";

            // Extras 메뉴에서 넘겨진 토큰 정보가 있는지 확인
            if (NavigationContext.QueryString.ContainsKey("token") == true)
            {
                strFileId = NavigationContext.QueryString["token"];
            }
            // Share... 메뉴에서 넘겨진 토큰 정보가 있는지 확인
            else if (NavigationContext.QueryString.ContainsKey("FileId") == true)
            {
                strFileId = NavigationContext.QueryString["FileId"];
            }

            if (strFileId.Length > 0)
            {

                // Media Library에서 토큰에 해당하는 이미지 얻기
                MediaLibrary library = new MediaLibrary();
                Picture picture = library.GetPictureFromToken(strFileId);

                // 해당 이미지 파일을 페이지에 출력하기
                txtPictureInfo.Text = picture.Name + "(" + picture.Date + ")";

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(picture.GetImage());  
                WriteableBitmap bitmap = new WriteableBitmap(bitmapImage);

                // 원본 이미지를 좌우로 뒤집은 후에 화면에 출력한다.
                imgPicture.Source = GetConvertedBitmap(bitmap);
            }
            else
            {
                // extras 메뉴를 통하지 않고 직접 애플리케이션이 실행된 경우이다.
                // PhotoChooserTask를 이용해서 사진을 선택하도록 구현할 수 있다.
            }
        }

        private WriteableBitmap GetConvertedBitmap(WriteableBitmap bitmap)
        {
            int[,] arr = new int[bitmap.PixelWidth, bitmap.PixelHeight];

            // bitmap의 픽셀 정보를 좌우를 뒤집어서 2차원 배열로 추출한다.
            for (int row = 0; row < bitmap.PixelHeight; row++) 
            {
                for (int col = 0; col < bitmap.PixelWidth; col++)
                {
                    arr[bitmap.PixelWidth - col - 1, row] = 
                        bitmap.Pixels[bitmap.PixelWidth * row + col];
                }
            }

            // 추출한 배열을 다시 원래 bitmap의 픽셀 정보로 저장한다.
            for (int row = 0; row < bitmap.PixelHeight; row++) 
            {
                for (int col = 0; col < bitmap.PixelWidth; col++)
                {
                    bitmap.Pixels[bitmap.PixelWidth * row + col] = arr[col, row];
                }
            }

            // 좌우가 변경된 bitmap 이미지를 임시 파일로 저장한다.
            SaveTempFile(bitmap);
            return bitmap;
        }

        private void SaveTempFile(WriteableBitmap bitmap)
        {
            string strTempFileName = "temp.jpg";

            // 격리 저장소에 이전 임시파일이 있으면 삭제한다.
            var myStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (myStore.FileExists(strTempFileName))
            {
                myStore.DeleteFile(strTempFileName);
            }

            // 임시파일을 만들고 JPG 형식으로 bitmap을 저장한다.
            IsolatedStorageFileStream myFileStream = myStore.CreateFile(strTempFileName);
            Extensions.SaveJpeg(bitmap, myFileStream, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
            myFileStream.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string strTempFileName = "temp.jpg";

            // 격리 저장소에 저장된 임시파일 열기
            var myStore = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream myFileStream = 
                myStore.OpenFile(strTempFileName, FileMode.Open, FileAccess.Read);

            // 임시파일을 미디어 라이브러리에 저장한다.
            MediaLibrary library = new MediaLibrary();
            Picture pic = library.SavePicture("RotatedPicture.jpg", myFileStream);
            myFileStream.Close();

        }
    }

}