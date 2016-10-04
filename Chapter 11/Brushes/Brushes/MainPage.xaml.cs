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

namespace Brushes
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSolidBrush_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Solid.xaml", UriKind.Relative));
        }

        private void btnGradientBrush_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Gradient.xaml", UriKind.Relative));
        }

        private void btnImageBrush_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Image.xaml", UriKind.Relative));
        }
    }
}