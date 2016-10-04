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

namespace Controls
{
    public partial class Image : PhoneApplicationPage
    {
        public Image()
        {
            InitializeComponent();
        }

        private void radioNone_Checked(object sender, RoutedEventArgs e)
        {
            imgMySon.Stretch = Stretch.None;
        }

        private void radioFill_Checked(object sender, RoutedEventArgs e)
        {
            imgMySon.Stretch = Stretch.Fill;
        }

        private void radioUniform_Checked(object sender, RoutedEventArgs e)
        {
            imgMySon.Stretch = Stretch.Uniform;
        }

        private void radioUniformToFill_Checked(object sender, RoutedEventArgs e)
        {
            imgMySon.Stretch = Stretch.UniformToFill;
        }
    }
}