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


namespace CompassApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        Compass compass;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (Compass.IsSupported == false)
            {
                MessageBox.Show("콤파스 센서를 사용할 수 없습니다.");
                return;
            }

            if (compass == null)
            {
                compass = new Compass();
            }
            compass.TimeBetweenUpdates = TimeSpan.FromMilliseconds(1);
            compass.CurrentValueChanged += compass_CurrentValueChanged;

            try
            {
                compass.Start();
            }
            catch (SensorFailedException ex)
            {
                MessageBox.Show("콤파스 센서를 시작할 수 없습니다." + ex.Message);
                return;
            }

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;

        }


        void compass_CurrentValueChanged(object sender, SensorReadingEventArgs<CompassReading> e)
        {
            String strStatus =
                "HeadingAccuracy : " + e.SensorReading.HeadingAccuracy.ToString() +
                "\nMagneticHeading : " + e.SensorReading.MagneticHeading.ToString() +
                "\nManetometerReading : " + e.SensorReading.MagnetometerReading.ToString() +
                "\nTrueHeading : " + e.SensorReading.TrueHeading.ToString() +
                "\nTimestamp : " + e.SensorReading.Timestamp.ToString();
                
            Dispatcher.BeginInvoke(delegate()
            {
                txtStatus.Text = strStatus;
                rotateCompass.Angle = 360 - e.SensorReading.MagneticHeading;
            });
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            compass.Stop();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (compass != null)
            {
                // 콤파스 센서에서 사용한 자원 해제
                compass.Stop();
                compass.Dispose();
                compass = null;
            }
        }
    }
}