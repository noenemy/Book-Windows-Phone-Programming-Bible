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

namespace PassingData
{
    public partial class SecondPage : PhoneApplicationPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string data = "";

             // 전달된 데이터가 있으면 화면에 출력한다.
            if (NavigationContext.QueryString.TryGetValue("data", out data))
                txtReceivedData.Text = data;
            
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = 
                MessageBox.Show("이 페이지를 벗어나겠습니까?", "질문", MessageBoxButton.OKCancel);

            // 사용자가 취소한 경우 현재 페이지를 유지한다.
            if (result == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

   }
}