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

namespace PageOrientation
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ShowCurrentOrientation();
        }

        // 페이지 방향이 변경될 때 호출됨
        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            ShowCurrentOrientation();
        }

        // 현재 페이지의 방향을 출력하는 함수
        private void ShowCurrentOrientation()
        {
            btnButton.Content = this.Orientation.ToString();
        }
    }
}