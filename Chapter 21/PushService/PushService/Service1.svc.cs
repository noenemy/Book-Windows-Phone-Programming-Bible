using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace PushService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class PushService : IPushService
    {
        private static List<Uri> subscribers = new List<Uri>();

        public void Register(string strURI)
        {
            Uri newUri = new Uri(strURI, UriKind.Absolute);
            if (subscribers.Contains(newUri) == false)
            {
                subscribers.Add(newUri);
            }
        }

        public void Unregister(string strURI)
        {
            Uri deleteUri = new Uri(strURI, UriKind.Absolute);
            subscribers.Remove(deleteUri);
        }

        public void SendToastNotification(string strTitle, string strSubtitle)
        {
            string notificationStatus = "";
            string notificationChannelStatus = "";
            string deviceConnectionStatus = "";

            // 구독한 애플리케이션들에 대해서 푸시 알림 보내기
            foreach (Uri channelUri in subscribers)
            {
                // 토스트 알림 헤더 구성하기
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(channelUri);
                request.Method = "POST";
                request.ContentType = "text/xml; charset=utf-8";
                request.Headers["X-MessageID"] = Guid.NewGuid().ToString();
                request.Headers.Add("X-NotificationClass", "2");
                request.Headers.Add("X-WindowsPhone-Target", "toast");

                // 토스트 알림 데이터 구성하기
                string notificationData = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                        "<wp:Notification xmlns:wp=\"WPNotification\">" +
                          "<wp:Toast>" +
                            "<wp:Text1>" + strTitle + "</wp:Text1>" +
                            "<wp:Text2>" + strSubtitle + "</wp:Text2>" +
                          "</wp:Toast>" +
                        "</wp:Notification>";

                byte[] contents = Encoding.UTF8.GetBytes(notificationData);
                request.ContentLength = contents.Length;

                try
                {
                    // 알림 요청 스트림 보내기
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(contents, 0, contents.Length);
                    }

                    // Microsoft Notification Server로부터 HttpWebResponse 상태값 받기
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        notificationStatus = response.Headers["X-NotificationStatus"];
                        notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
                        deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
                    }

                    Debug.WriteLine(notificationStatus + " : " + notificationChannelStatus + " : " + deviceConnectionStatus);
                }
                catch (Exception ex)
                {
                    // TODO : 예외 상황에 따른 처리 루틴 필요
                    Debug.WriteLine(ex.Message);
                }                
            }

        }

        public void SendTileNotification(int nCount, string strTitle, string strBackground)
        {
            string notificationStatus = "";
            string notificationChannelStatus = "";
            string deviceConnectionStatus = "";

            // 구독한 애플리케이션들에 대해서 푸시 알림 보내기
            foreach (Uri channelUri in subscribers)
            {
                // 타일 알림 헤더 구성하기
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(channelUri);
                request.Method = "POST";
                request.ContentType = "text/xml; charset=utf-8";
                request.Headers["X-MessageID"] = Guid.NewGuid().ToString();
                request.Headers.Add("X-NotificationClass", "1");
                request.Headers.Add("X-WindowsPhone-Target", "token");


                // 타일 알림 데이터 구성하기
                string tileMessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<wp:Notification xmlns:wp=\"WPNotification\">" +
                      "<wp:Tile>" +
                      "<wp:BackgroundImage>" + strBackground + "</wp:BackgroundImage>" +
                        "<wp:Count>" + nCount.ToString() + "</wp:Count>" +
                        "<wp:Title>" + strTitle + "</wp:Title>" +
                      "</wp:Tile> " +  
                    "</wp:Notification>";

                byte[] contents = Encoding.UTF8.GetBytes(tileMessage);
                request.ContentLength = contents.Length;

                try
                {

                    // 알림 요청 스트림 보내기
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(contents, 0, contents.Length);
                    }

                    // Microsoft Notification Server로부터 HttpWebResponse 상태값 받기
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        notificationStatus = response.Headers["X-NotificationStatus"];
                        notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
                        deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
                    }

                    Debug.WriteLine(notificationStatus + " : " + notificationChannelStatus + " : " + deviceConnectionStatus);
                }
                catch (Exception ex)
                {
                    // TODO : 예외 상황에 따른 처리 루틴 필요
                    Debug.WriteLine(ex.Message);
                }                
            }
        }

        public void SendRawNotification(string strMessage)
        {
            string notificationStatus = "";
            string notificationChannelStatus = "";
            string deviceConnectionStatus = "";

            // 구독한 애플리케이션들에 대해서 푸시 알림 보내기
            foreach (Uri channelUri in subscribers)
            {
                // Raw 알림 헤더 구성하기
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(channelUri);
                request.Method = "POST";
                request.ContentType = "text/xml; charset=utf-8";
                request.Headers["X-MessageID"] = Guid.NewGuid().ToString();
                request.Headers.Add("X-NotificationClass", "3");

                // Raw 알림 데이터 구성하기
                byte[] contents = Encoding.UTF8.GetBytes(strMessage);
                request.ContentLength = contents.Length;

                try
                {

                    // 알림 요청 스트림 보내기
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(contents, 0, contents.Length);
                    }

                    // Microsoft Notification Server로부터 HttpWebResponse 상태값 받기
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        notificationStatus = response.Headers["X-NotificationStatus"];
                        notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
                        deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
                    }

                    Debug.WriteLine(notificationStatus + " : " + notificationChannelStatus + " : " + deviceConnectionStatus);

                }
                catch (Exception ex)
                {
                    // TODO : 예외 상황에 따른 처리 루틴 필요
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
