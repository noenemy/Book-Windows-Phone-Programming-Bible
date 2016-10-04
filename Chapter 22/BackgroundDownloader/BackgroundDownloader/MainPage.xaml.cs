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

using Microsoft.Phone.BackgroundTransfer;
using System.IO.IsolatedStorage;   


namespace BackgroundDownloader
{
    public partial class MainPage : PhoneApplicationPage
    {
        BackgroundTransferRequest transferRequest;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            // 다운로드 대상 파일의 경로
            string filePath = "http://create.msdn.com/assets/cms/images/samples/windowsphonetestfile1.png";
            
            Uri transferUri = new Uri(Uri.EscapeUriString(filePath), UriKind.RelativeOrAbsolute);
            transferRequest = new BackgroundTransferRequest(transferUri);

            // 로컬에 저장할 경로
            string downloadFile = filePath.Substring(filePath.LastIndexOf("/") + 1);
            Uri downloadUri = new Uri("shared/transfers/" + downloadFile, UriKind.RelativeOrAbsolute);
            transferRequest.DownloadLocation = downloadUri;

            transferRequest.Method = "GET";

            // TransferPreferences 설정
            transferRequest.TransferPreferences = TransferPreferences.None;

            if (chkWiFiOnly.IsChecked == false)
            {
                transferRequest.TransferPreferences = TransferPreferences.AllowCellular;
            }
            if (chkExternalPowerOnly.IsChecked == false)
            {
                transferRequest.TransferPreferences = TransferPreferences.AllowBattery;
            }
            if ((chkWiFiOnly.IsChecked == false) && (chkExternalPowerOnly.IsChecked == false))
            {
                transferRequest.TransferPreferences = TransferPreferences.AllowCellularAndBattery;
            }

            // 백그라운드 전송 요청하기
            try
            {
                transferRequest.TransferProgressChanged += transferRequest_TransferProgressChanged;
                transferRequest.TransferStatusChanged += transferRequest_TransferStatusChanged;

                BackgroundTransferService.Add(transferRequest);

                stackProgress.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("백그라운드 전송 실패. " + ex.Message);
            }
            
        }

        void transferRequest_TransferStatusChanged(object sender, BackgroundTransferEventArgs e)
        {
            // 전송 상태 정보를 화면에 출력하기
            txtStatus.Text = e.Request.TransferStatus.ToString();

            switch (e.Request.TransferStatus)
            {
                case TransferStatus.Transferring:                    
                    btnDownload.IsEnabled = false;
                    btnCancel.IsEnabled = true;
                    break;
                case TransferStatus.Completed:
                    btnDownload.IsEnabled = true;
                    btnCancel.IsEnabled = false;
                    // 전송이 성공했으면 요청 목록에서 제거
                    if (e.Request.StatusCode == 200 || e.Request.StatusCode == 206)
                        BackgroundTransferService.Remove(e.Request);
                    break;
            }

        }

        void transferRequest_TransferProgressChanged(object sender, BackgroundTransferEventArgs e)
        {
            // 전송 파일과 전송률 정보를 화면에 출력한다.
            txtPath.Text = e.Request.RequestUri.ToString();
            txtProgress.Text = "(" + e.Request.BytesReceived.ToString() + "/" + e.Request.TotalBytesToReceive + ")";

            // ProgressBar 위치 지정
            progressTransfer.Maximum = e.Request.TotalBytesToReceive;
            progressTransfer.Value = e.Request.BytesReceived;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // 백그라운드 전송 요청을 취소하고 큐에서 제거한다.
            BackgroundTransferService.Remove(transferRequest);

            // UI 초기화
            txtStatus.Text = "";
            txtProgress.Text = "";
            txtPath.Text = "";
            progressTransfer.Value = 0;
            stackProgress.Visibility = Visibility.Collapsed;

        }
    }
}