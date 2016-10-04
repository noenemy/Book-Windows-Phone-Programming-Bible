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
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;

namespace Choosers
{
    public partial class CameraCapture : PhoneApplicationPage
    {

        CameraCaptureTask cameraCaptureTask;

        public CameraCapture()
        {
            InitializeComponent();

            cameraCaptureTask = new CameraCaptureTask();
            cameraCaptureTask.Completed += new EventHandler<PhotoResult>(cameraCaptureTask_Completed);
        }

        void cameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(e.ChosenPhoto);
                imgCapture.Source = bitmapImage;
            }
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            cameraCaptureTask.Show();
        }
    }
}