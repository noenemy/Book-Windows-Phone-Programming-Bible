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
    public partial class Marketplace : PhoneApplicationPage
    {
        public Marketplace()
        {
            InitializeComponent();
        }

        private void btnMusic_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceHubTask marketplaceHubTask = new MarketplaceHubTask();
            marketplaceHubTask.ContentType = MarketplaceContentType.Music;
            marketplaceHubTask.Show();

        }

        private void btnApplication_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceHubTask marketplaceHubTask = new MarketplaceHubTask();
            marketplaceHubTask.ContentType = MarketplaceContentType.Applications;
            marketplaceHubTask.Show();
        }

        private void btnReviewTask_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void btnSearchTask_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();
            marketplaceSearchTask.SearchTerms = "compass";
            marketplaceSearchTask.Show();

        }
    }
}