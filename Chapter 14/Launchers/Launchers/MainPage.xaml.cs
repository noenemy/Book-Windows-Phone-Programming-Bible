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

namespace Launchers
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceHubTask marketplaceHubTask = new MarketplaceHubTask();
            marketplaceHubTask.ContentType = MarketplaceContentType.Music;
            marketplaceHubTask.Show();

        }

        private void btnEmailComposeTask_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate (new Uri("/EmailCompose.xaml", UriKind.Relative));
        }

        private void btnMarketPlaceTasks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Marketplace.xaml", UriKind.Relative));
        }

        private void btnMediaPlayerLancher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MediaPlayer.xaml", UriKind.Relative));
        }

        private void btnPhoneCallTask_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PhoneCall.xaml", UriKind.Relative));
        }

        private void btnSearchTask_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        private void btnSMSComposeTask_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SMSCompose.xaml", UriKind.Relative));
        }

        private void btnWebBrowserTask_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/WebBrowser.xaml", UriKind.Relative));
        }

        private void btnBingMapsTask_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BingMaps.xaml", UriKind.Relative));
        }
    }
}