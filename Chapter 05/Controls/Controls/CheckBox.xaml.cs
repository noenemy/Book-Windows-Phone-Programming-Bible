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
    public partial class CheckBox : PhoneApplicationPage
    {
        public CheckBox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string strMsg = "";

            // 첫번째 체크박스 값 확인
            if (chkNuno.IsChecked == true)
            {
                strMsg += chkNuno.Content;
            }

            // 두번째 체크박스 값 확인
            if (chkPat.IsChecked == true)
            {
                if (strMsg.Length > 0) strMsg += ",";
                strMsg += chkPat.Content;
            }

            // 세번째 체크박스 값 확인
            if (chkJohn.IsChecked == true)
            {
                if (strMsg.Length > 0) strMsg += ",";
                strMsg += chkJohn.Content;
            }
            else if (chkJohn.IsChecked == null)
            {
                // Indeterminate 인 경우에 대한 처리
                if (strMsg.Length > 0) strMsg += ",";
                strMsg += chkJohn.Content + "(?)";
            }

            // 메시지 출력하기
            if (strMsg.Length == 0)
                strMsg = "좋아하는 뮤지션이 없습니다.";
            else
                strMsg += "를 좋아하시는군요.";

            MessageBox.Show(strMsg);
        }

    }
}