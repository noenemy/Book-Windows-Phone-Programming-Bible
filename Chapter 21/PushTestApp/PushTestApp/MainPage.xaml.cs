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
using Microsoft.Phone.Notification;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace PushTestApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        HttpNotificationChannel httpChannel = null;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCreateChannel_Click(object sender, RoutedEventArgs e)
        {
            httpChannel = HttpNotificationChannel.Find("MyTestChannel");
            if (httpChannel != null)
            {
                WriteStatus("이전에 등록된 채널 정보를 제거합니다.");

                httpChannel.UnbindToShellToast();
                httpChannel.UnbindToShellTile();
                httpChannel.Close();
            }

            SetUpChannel();
        }

        private void WriteStatus(string strStatus)
        {
            txtStatus.Text = strStatus + "\n" + txtStatus.Text;
        }

        private void SetUpChannel()
        {
            httpChannel = new HttpNotificationChannel("MyTestChannel");

            // 이벤트 핸들러 등록
            httpChannel.ChannelUriUpdated += httpChannel_ChannelUriUpdated;
            httpChannel.ErrorOccurred += httpChannel_ErrorOccurred;

            try
            {
                WriteStatus("새로운 채널을 등록합니다.");
                httpChannel.Open();
            }
            catch (Exception ex)
            {
                WriteStatus("채널 등록 실패:" + ex.Message);
            }
        }

        void httpChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            WriteStatus("채널에서 오류 발생: " + e.Message);

            switch (e.ErrorType)
            {
                case ChannelErrorType.ChannelOpenFailed:
                    // ...
                    break;
                case ChannelErrorType.MessageBadContent:
                    // ...
                    break;
                case ChannelErrorType.NotificationRateTooHigh:
                    // ...
                    break;
                case ChannelErrorType.PayloadFormatError:
                    // ...
                    break;
                case ChannelErrorType.PowerLevelChanged:
                    // ...
                    break;
                default:
                    break;
            }
        }

        void httpChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                WriteStatus("채널 등록 완료: " + e.ChannelUri.ToString());
                Debug.WriteLine(e.ChannelUri.ToString());
            });
            
            // 메시지 수신 이벤트 핸들러 등록
            httpChannel.ShellToastNotificationReceived += httpChannel_ShellToastNotificationReceived;
            httpChannel.HttpNotificationReceived += httpChannel_HttpNotificationReceived;

            // 채널을 쉘에 바인딩 시키기
            httpChannel.BindToShellToast();
            httpChannel.BindToShellTile();
        }

        void httpChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            if (e.Notification.Body != null && e.Notification.Headers != null)
            {
                StreamReader reader = new StreamReader(e.Notification.Body);
                Dispatcher.BeginInvoke(delegate()
                {
                    WriteStatus("Raw 알림 수신: " + reader.ReadToEnd());
                });
            }
        }

        void httpChannel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                if (e.Collection != null)
                {
                    Dictionary<string, string> collection = (Dictionary<string, string>)e.Collection;
                    StringBuilder messageBuilder = new StringBuilder();
                    foreach (string elementName in collection.Keys)
                    {
                        WriteStatus("토스트 알림 수신: " + elementName + "," + collection[elementName] );
                    }
                }
            });
        }
    }
}