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

namespace Brushes
{
    public partial class Solid : PhoneApplicationPage
    {
        public Solid()
        {
            InitializeComponent();

            Rectangle rect = new Rectangle();
            rect.Height = 50;
            rect.Width = 100;
            //rect.Fill = new SolidColorBrush(Colors.Blue);

            rect.Fill = new SolidColorBrush(Color.FromArgb(150, 0, 0, 255));
            myCanvas.Children.Add(rect);
        }
    }
}