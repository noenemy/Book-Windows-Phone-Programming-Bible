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

namespace Choosers
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCameraCapture_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CameraCapture.xaml", UriKind.Relative));
        }

        private void btnEmailAddress_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmailAddress.xaml", UriKind.Relative));
        }

        private void btnPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PhoneNumber.xaml", UriKind.Relative));
        }

        private void btnPhotoChooser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PhotoChooser.xaml", UriKind.Relative));
        }

        private void btnSaveEmailAddress_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SaveEmailAddress.xaml", UriKind.Relative));
        }

        private void btnSavePhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SavePhoneNumber.xaml", UriKind.Relative));
        }

        private void btnAddress_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Address.xaml", UriKind.Relative));
        }

        private void btnGameInvite_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GameInvite.xaml", UriKind.Relative));
        }
    }
}