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
using Microsoft.Phone.Marketplace;

namespace TrialApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public LicenseInformation licenseInfo;           

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            licenseInfo = new LicenseInformation();
        }

        private void btnGoFreePage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Free.xaml", UriKind.Relative));
        }

        private void btnGoAdvancedPage_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIsTrial() == false)
            {
                NavigationService.Navigate(new Uri("/Advanced.xaml", UriKind.Relative));
            }
            else
            {
                // 평가판 버전일 경우 제품 상세 정보 페이지로 이동한다.
                MarketplaceDetailTask task = new MarketplaceDetailTask();
                task.Show();
            }
        }  

        private bool CheckIsTrial() 
        {
#if DEBUG
            // DEBUG 모드에서 마켓플레이스를 시뮬레이션 하기 위한 코드
            MessageBoxResult result = MessageBox.Show("OK 버튼을 클릭하면 구매한 것으로 동작합니다.","평가판 시뮬레이션",MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                // OK 버튼 클릭시 마켓플레이스에서 구매한 것으로 간주하고 false를 리턴한다.
                return false;
            }            
            else
            {
                // Cancel 버튼 클릭시 구매하지 않은 것으로 간주하고 true를 리턴한다.
                return true;
            }
#else
            // RELEASE 모드에서는 실제 라이센스 정보를 이용해서 동작한다.
            return licenseInfo.IsTrial();
  
#endif
        }
        
    }
}