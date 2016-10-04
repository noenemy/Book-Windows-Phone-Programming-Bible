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
    public partial class Slider : PhoneApplicationPage
    {
        public Slider()
        {
            InitializeComponent();
            sliderOpacity.Value = 50;
        }

        private void sliderOpacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtOpacity.Opacity = sliderOpacity.Value / 100;
            txtOpacity.Text = "불투명도:" + Convert.ToInt32(sliderOpacity.Value).ToString() + "%";
        }
    }
}