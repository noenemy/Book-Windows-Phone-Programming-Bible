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
using System.Device.Location;

namespace Launchers
{
    public partial class BingMaps : PhoneApplicationPage
    {
        public BingMaps()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            BingMapsTask bingMapsTask = new BingMapsTask();

            bingMapsTask.SearchTerm = txtSearchTerm.Text;
            bingMapsTask.ZoomLevel = 2;

            bingMapsTask.Show();

        }
    }
}