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

namespace MotionApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        Motion motion;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (Motion.IsSupported == false)
            {
                MessageBox.Show("모션 센서를 사용할 수 없습니다.");
                return;
            }

            if (motion == null)
            {
                motion = new Motion();
            }
            motion.TimeBetweenUpdates = TimeSpan.FromMilliseconds(1);
            motion.CurrentValueChanged += motion_CurrentValueChanged;

            try
            {
                motion.Start();
            }
            catch (SensorFailedException ex)
            {
                MessageBox.Show("모션 센서를 시작할 수 없습니다. " + ex.Message);
                return;
            }
             * */

            String strStatus =
                "DeviceAcceleration :\n {X:-0.103771 Y:-0.0602753 Z:0.09784853}" +

                "\n\nDeviceRotationRate :\n  {X:-0.7404639 Y:-0.3957183 Z:0.2444369}" +

                "\n\nGravity :\n  {X:-0.002109177 Y:-0.2596888 Z:-0.96569}" +

                "\n\nAttitude : " +
                "\n-Pitch : 0.2627006" +
                "\n-Quaternion : {X:0.05588241 Y:0.1184573 Z:0.90002}" +
                "\n-Roll : -0.00210917" +
                "\n-RotationMatrix : { {M11:-0.6481634 M12:-0.7350196" +
                "\n-Yaw : 2.275968" +

                "\n\nTimestamp : 7/3/2011 06:45:38 AM +09:00";

            txtStatus.Text = strStatus;

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            motion.Stop();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        void motion_CurrentValueChanged(object sender, SensorReadingEventArgs<MotionReading> e)
        {
            String strStatus =
                "DeviceAcceleration :\n " + e.SensorReading.DeviceAcceleration.ToString() +

                "\n\nDeviceRotationRate :\n " + e.SensorReading.DeviceRotationRate.ToString() +

                "\n\nGravity :\n " + e.SensorReading.Gravity.ToString() +
                
                "\n\nAttitude : " + 
                "\n-Pitch : " + e.SensorReading.Attitude.Pitch.ToString() +
                "\n-Quaternion : " + e.SensorReading.Attitude.Quaternion.ToString() +
                "\n-Roll : " + e.SensorReading.Attitude.Roll.ToString() +
                "\n-RotationMatrix : " + e.SensorReading.Attitude.RotationMatrix.ToString() +
                "\n-Yaw : " + e.SensorReading.Attitude.Yaw.ToString() +

                "\n\nTimestamp : " + e.SensorReading.Timestamp.ToString();

            Dispatcher.BeginInvoke(delegate()
            {
                txtStatus.Text = strStatus;
            });
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (motion != null)
            {
                // 모션 센서에서 사용한 자원 해제
                motion.Stop();
                motion.Dispose();
                motion = null;
            }
        }
    
    }
}