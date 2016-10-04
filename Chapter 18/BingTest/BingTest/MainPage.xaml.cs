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
using Microsoft.Phone.Controls.Maps;

namespace BingTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            myMap.CredentialsProvider = new ApplicationIdCredentialsProvider("My Key");

        }

        private void btnFindCurrentPosition_Click(object sender, RoutedEventArgs e)
        {
            //map1.Center = new GeoCoordinate(37.514, 126.956);
            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                watcher.MovementThreshold = 20;
                watcher.PositionChanged += watcher_PositionChanged;
            }
            watcher.Start();
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            myMap.Center = new GeoCoordinate(e.Position.Location.Latitude,e.Position.Location.Longitude);
            watcher.Stop();
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel--;
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel++;
        }

        private void btnAerialMode_Click(object sender, RoutedEventArgs e)
        {
            myMap.Mode = new AerialMode();
        }

        private void btnRoadMode_Click(object sender, RoutedEventArgs e)
        {
            myMap.Mode = new RoadMode();
        }

    }
}