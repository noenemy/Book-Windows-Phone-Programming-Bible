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

namespace SimplePlayer
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool m_bIsSeeking = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            ShowPlayStatus();
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            // 가로 방향 보기일 때에는 TitlePanel을 숨긴다.
            if (this.Orientation == PageOrientation.LandscapeLeft ||
                this.Orientation == PageOrientation.LandscapeRight)
            {
                TitlePanel.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                TitlePanel.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void mediaPlayer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ApplicationBar.IsVisible = !ApplicationBar.IsVisible;
           
        }

        private void ShowPlayStatus()
        {
            if (txtMediaName.Text.Length > 0)
            {
                TimeSpan time = mediaPlayer.Position;
                TimeSpan duration = mediaPlayer.NaturalDuration.TimeSpan;
                double doubleProgress = time.TotalSeconds / duration.TotalSeconds;
                string text = string.Format("{0}:{01}:{02}/{3}:{04}:{05} ({06}%)",
                    time.Hours, time.Minutes, time.Seconds,
                    duration.Hours, duration.Minutes, duration.Seconds,
                    (int)doubleProgress * 100);

                // 내용이 변경된 경우에만 화면에 출력한다.
                if (txtStatus.Text != text)
                {
                    txtStatus.Text = text + mediaPlayer.CurrentState.ToString();
                    if (m_bIsSeeking != true)
                    {
                        sliderPosition.Value = doubleProgress * duration.TotalSeconds;
                    }
                }
            }
        }

        private void mediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            txtMediaName.Text = mediaPlayer.Source.ToString();
            sliderPosition.Minimum = 0; 
            sliderPosition.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;

            ShowPlayStatus();
        }

        private void mediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void btnStretchNone_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stretch = Stretch.None;
        }

        private void btnStretchFill_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stretch = Stretch.Fill;
        }

        private void btnStretchUniform_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stretch = Stretch.Uniform;
        }

        private void btnStretchUniformToFill_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stretch = Stretch.UniformToFill;
        }

        private void sliderPosition_LostMouseCapture(object sender, MouseEventArgs e)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds((int)sliderPosition.Value);
            m_bIsSeeking = false;
        }

        private void sliderPosition_MouseEnter(object sender, MouseEventArgs e)
        {
            m_bIsSeeking = true;
        }

        private void mediaPlayer_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            ShowPlayStatus();
        }

    }
}