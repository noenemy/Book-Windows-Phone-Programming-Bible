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
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnTextBlock_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TextBlock.xaml",UriKind.Relative));
        }

        private void btnTextBox_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TextBox.xaml", UriKind.Relative));
        }

        private void txtInputScope_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InputScope.xaml", UriKind.Relative));
        }

        private void btnPassword_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Password.xaml", UriKind.Relative));
        }

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Button.xaml", UriKind.Relative));
        }

        private void btnCheckBox_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CheckBox.xaml", UriKind.Relative));
        }

        private void btnRadioButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RadioButton.xaml", UriKind.Relative));
        }

        private void btnHyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Hyperlink.xaml", UriKind.Relative));
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Image.xaml", UriKind.Relative));
        }

        private void lnkSlider_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Slider.xaml", UriKind.Relative));
        }

        private void btnProgressBar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ProgressBar.xaml", UriKind.Relative));
        }

        private void btnWebBrowser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/WebBrowser.xaml", UriKind.Relative));
        }

        private void btnListBox_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ListBox.xaml", UriKind.Relative));
        }

        private void btnScollViewer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScrollViewer.xaml", UriKind.Relative));
        }
    }
}