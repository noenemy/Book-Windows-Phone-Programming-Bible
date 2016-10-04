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
    public partial class TextBox : PhoneApplicationPage
    {
        public TextBox()
        {
            InitializeComponent();
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Trim() == "이름을 입력하세요")
                txtName.Text = "";
        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Trim() == "")
                txtName.Text = "이름을 입력하세요";
        }
    }
}