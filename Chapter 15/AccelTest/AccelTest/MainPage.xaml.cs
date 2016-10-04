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

namespace AccelTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        Accelerometer accel;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            accel = new Accelerometer();
            accel.ReadingChanged +=new EventHandler<AccelerometerReadingEventArgs>(accel_ReadingChanged);
        }

        void  accel_ReadingChanged(object sender, AccelerometerReadingEventArgs e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                txtX.Text = e.X.ToString("0.0000");
                txtY.Text = e.Y.ToString("0.0000");
                txtZ.Text = e.Z.ToString("0.0000");
                txtTimestamp.Text = e.Timestamp.ToString();
            });

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                accel.Start();

                btnStart.IsEnabled = false;
                btnStop.IsEnabled = true;
            }
            catch (AccelerometerFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                accel.Stop();

                btnStart.IsEnabled = true;
                btnStop.IsEnabled = false;
            }
            catch (AccelerometerFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}