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
using System.IO.IsolatedStorage;

namespace MySettings
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // IsolatedStorageSetting 값을 읽어와서 컨트롤을 초기화한다.
            string value = "";
            value = ReadSetting("Background", "Black");
            switch (value)
            {
                case "Red":
                    radioRed.IsChecked = true;
                    break;
                case "Blue":
                    radioBlue.IsChecked = true;
                    break;
                case "Black":
                    radioBlack.IsChecked = true;
                    break;
            }

            value = ReadSetting("Opacity", "1");
            sliderOpacity.Value = Convert.ToDouble(value);

        }

        private void SaveSetting(string key, string value)
        {            
            IsolatedStorageSettings.ApplicationSettings[key] = value;
        }

        private string ReadSetting(string key, string defaultValue)
        {
            string value = "";
            if (IsolatedStorageSettings.ApplicationSettings.TryGetValue(key, out value) == true)
            {
                return value;
            }

            return defaultValue;

        }

        private void radioRed_Checked(object sender, RoutedEventArgs e)
        {
            SaveSetting("Background", "Red");
            this.LayoutRoot.Background = new SolidColorBrush(Colors.Red);
        }

        private void radioBlue_Checked(object sender, RoutedEventArgs e)
        {
            SaveSetting("Background", "Blue");
            this.LayoutRoot.Background = new SolidColorBrush(Colors.Blue);
        }

        private void radioBlack_Click(object sender, RoutedEventArgs e)
        {
            SaveSetting("Background", "Black");
            this.LayoutRoot.Background = new SolidColorBrush(Colors.Black);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity = e.NewValue;
        }

        private void Slider_LostMouseCapture(object sender, MouseEventArgs e)
        {
            SaveSetting("Opacity", sliderOpacity.Value.ToString());
            this.Opacity = sliderOpacity.Value;
        }


    }
}