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
    public partial class RadioButton : PhoneApplicationPage
    {
        public RadioButton()
        {
            InitializeComponent();
        }

        private void HandleChecked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton radioButton = 
                           sender as System.Windows.Controls.RadioButton;
            string strMsg = "";
           
            // 선택된 RadioButton이 Gender 그룹에 속하는지 확인
            if (radioButton.GroupName == "Gender")
            {
                strMsg = "당신의 성별은 " + radioButton.Content + "입니다.";
            }
            // 선택된 RadioButton이 Phone 그룹에 속하는지 확인
            else if (radioButton.GroupName == "Phone")
            {
                strMsg = "당신은 " + radioButton.Content + "를 좋아합니다.";
            }

            MessageBox.Show(strMsg);            
        }

    }
}