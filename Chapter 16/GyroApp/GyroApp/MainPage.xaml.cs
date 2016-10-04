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

using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

namespace GyroApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        Gyroscope gyroscope;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (Gyroscope.IsSupported == false)
            {
                MessageBox.Show("자이로스코프 센서를 사용할 수 없습니다.");
                return;
            }
            
            if (gyroscope == null)
            {
                gyroscope = new Gyroscope();
            }
            gyroscope.TimeBetweenUpdates = TimeSpan.FromMilliseconds(1);
            gyroscope.CurrentValueChanged += gyroscope_CurrentValueChanged;

            try
            {
                gyroscope.Start();
            }
            catch (SensorFailedException ex)
            {
                MessageBox.Show("자이로스코프 센서를 시작할 수 없습니다. " + ex.Message);
                return;
            }
            
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        void gyroscope_CurrentValueChanged(object sender, SensorReadingEventArgs<GyroscopeReading> e)
        {

            String strStatus =
                "X : " + e.SensorReading.RotationRate.X.ToString() +
                "\nY : " + e.SensorReading.RotationRate.Y.ToString() +
                "\nZ : " + e.SensorReading.RotationRate.Z.ToString() + 
                "\nTimestamp : " + e.SensorReading.Timestamp.ToString();

            Dispatcher.BeginInvoke(delegate()
            {
                txtStatus.Text = strStatus;                
            });
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            gyroscope.Stop();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (gyroscope != null)
            {
                // 자이로스코프 센서에서 사용한 자원 해제
                gyroscope.Stop();
                gyroscope.Dispose();
                gyroscope = null;
            }
        }
    }
}