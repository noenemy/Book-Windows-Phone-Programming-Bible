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
using System.Windows.Threading;

namespace Controls
{
    public partial class ProgressBar : PhoneApplicationPage
    {
        private DispatcherTimer timer;
        
        public ProgressBar()
        {
            InitializeComponent();

            // Dispatcher Timer 초기화
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick +=new EventHandler(timer_Tick);
        }

        void  timer_Tick(object sender, EventArgs e)
        {
            // progressbar의 value 값 증가
            if (progressBar2.Value < 100)
                progressBar2.Value += 2;
            else
                progressBar2.Value = 0;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;

            // Timer 시작
            timer.Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            
            // Timer 중지
            timer.Stop();
        }
    }
}