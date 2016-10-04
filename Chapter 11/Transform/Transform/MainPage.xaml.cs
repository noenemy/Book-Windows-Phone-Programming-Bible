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

namespace Transform
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnScaleTrasform_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScaleTransform.xaml", UriKind.Relative));
        }
        
        private void btnRotateTrasform_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RotateTransform.xaml", UriKind.Relative));
        }

        private void btnSkewTrasform_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SkewTransform.xaml", UriKind.Relative));
        }

        private void btnTranslateTrasform_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TranslateTransform.xaml", UriKind.Relative));
        }
    }
}