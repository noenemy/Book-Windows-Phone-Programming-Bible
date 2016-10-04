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

using Microsoft.Phone.BackgroundAudio;
using System.IO.IsolatedStorage;
using System.Windows.Resources;


namespace BackgroundPlayer
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            BackgroundAudioPlayer.Instance.PlayStateChanged += Instance_PlayStateChanged;
        }

        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            // 재생 상태에 따라 버튼 컨트롤 제어하기
            switch (BackgroundAudioPlayer.Instance.PlayerState)
            {
                case PlayState.Paused:
                    btnPlay.Content = "Play";
                    break;
                case PlayState.Playing:
                    btnPlay.Content = "Pause";
                    break;
                case PlayState.Stopped:
                    btnPlay.Content = "Play";
                    break;
                case PlayState.TrackReady:
                    btnPlay.IsEnabled = true;
                    break;
            }

            // 트랙 정보가 있으면 화면에 출력한다.
            if (BackgroundAudioPlayer.Instance.Track != null)
            {
                AudioTrack track = BackgroundAudioPlayer.Instance.Track;
                txtStatus.Text = BackgroundAudioPlayer.Instance.Track.Artist + " / " + BackgroundAudioPlayer.Instance.Track.Title;
            }
            
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            // 현재 미디어가 재생 중이면
            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            {
                // 현재 재생 중인 미디어를 일시중지 시킨다.
                BackgroundAudioPlayer.Instance.Pause();
            }
            else
            {
                // 현재 미디어를 재생한다.
                BackgroundAudioPlayer.Instance.Play();
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            // 이전 트랙으로 이동
            BackgroundAudioPlayer.Instance.SkipPrevious();

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // 다음 트랙으로 이동
            BackgroundAudioPlayer.Instance.SkipNext();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // 현재 애플리케이션에서 재생 중인 트랙이 있으면 해당 정보를 출력한다.
            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            {
                btnPlay.Content = "Pause";
                btnPlay.IsEnabled = true;
            }
        }

        private void btnCopyFiles_Click(object sender, RoutedEventArgs e)
        {
            // 애플리케이션과 함께 배포된 MP3 파일을 격리 저장소에 저장한다.
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string[] files = new string[] { "Kalimba.mp3", "Maid with the Flaxen Hair.mp3", "Sleep Away.mp3" };

                foreach (var _fileName in files)
                {
                    if (!storage.FileExists(_fileName))
                    {
                        string _filePath = "Media/" + _fileName;
                        StreamResourceInfo resource = Application.GetResourceStream(new Uri(_filePath, UriKind.Relative));

                        using (IsolatedStorageFileStream file = storage.CreateFile(_fileName))
                        {
                            int chunkSize = 4096;
                            byte[] bytes = new byte[chunkSize];
                            int byteCount;

                            while ((byteCount = resource.Stream.Read(bytes, 0, chunkSize)) > 0)
                            {
                                file.Write(bytes, 0, byteCount);
                            }
                        }
                    }
                }
            }
        }

    }
}