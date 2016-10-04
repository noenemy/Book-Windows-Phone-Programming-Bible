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

namespace Shapes
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnRectangle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Rectangle.xaml", UriKind.Relative));
        }

        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Ellipse.xaml", UriKind.Relative));
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Line.xaml", UriKind.Relative));
        }

        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Path.xaml", UriKind.Relative));
        }

        private void btnPolygon_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Polygon.xaml", UriKind.Relative));
        }

        private void btnPolyline_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Polyline.xaml", UriKind.Relative));
        }
    }
}