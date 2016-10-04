﻿using System;
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
    public partial class WebBrowser : PhoneApplicationPage
    {
        public WebBrowser()
        {
            InitializeComponent();
        }

        private void txtURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txtURL.Text.Trim().Length > 0)
                {
                    webBrowser1.Source = new Uri(txtURL.Text, UriKind.Absolute);
                }
            }
        }

    }
   
}