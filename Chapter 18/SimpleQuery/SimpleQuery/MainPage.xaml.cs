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
using System.Device.Location;

namespace SimpleQuery
{
    public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                ShowMyLocation(e);
            });
        }

        void ShowMyLocation(GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            txtLatitude.Text = e.Position.Location.Latitude.ToString("0.000");
            txtLongitude.Text = e.Position.Location.Longitude.ToString("0.000");
            txtAltitude.Text = e.Position.Location.Altitude.ToString("0.000");
            watcher.Stop();
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                watcher.MovementThreshold = 20;
                watcher.PositionChanged += watcher_PositionChanged;
            }
            watcher.Start();
        }
    }
}