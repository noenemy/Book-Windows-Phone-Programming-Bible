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

namespace Layout
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnBorder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new Uri("/Border.xaml", UriKind.Relative));
        }

        private void btnCanvas_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Canvas.xaml", UriKind.Relative));
        }

        private void btnGrid_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Grid.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/StackPanel.xaml", UriKind.Relative));
        }

        private void btnOrientation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Orientation.xaml", UriKind.Relative));
        }


    }
}