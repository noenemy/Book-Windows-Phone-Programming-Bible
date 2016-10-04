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
    public partial class PhotoChooser : PhoneApplicationPage
    {

        PhotoChooserTask photoChooserTask;

        public PhotoChooser()
        {
            InitializeComponent();

            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
        }

        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(e.ChosenPhoto);
                imgPhoto.Source = bitmapImage;
            }
        }


        private void btnGetPhoto_Click(object sender, RoutedEventArgs e)
        {
            photoChooserTask.Show();
        }
    }
}