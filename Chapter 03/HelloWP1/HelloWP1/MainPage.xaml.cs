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

namespace HelloWP1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            /*
            TextBox txtHello = new TextBox();
            txtHello.Text = "Hello Windows Phone";

            this.ContentPanel.Children.Add(txtHello);
            */

            Button btnHello = new Button();
            btnHello.Content = "Hello Windows Phone";

            this.ContentPanel.Children.Add(btnHello);
            
        }
    }
}