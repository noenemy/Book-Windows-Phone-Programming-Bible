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

namespace Points
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }

        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            TouchPointCollection points = e.GetTouchPoints(myCanvas);

            // 터치된 개수만큼 반복
            for (int i = 0; i < points.Count; i++)
            {
                // Ellipse 찾기
                string controlName = "ellipse" + i.ToString();
                Ellipse ellipse = (Ellipse)this.FindName(controlName);

                if (ellipse != null)
                {
                    // 해당 Ellipse를 터치된 위치로 이동한다.
                    TouchPoint pt = points[i];
                    Canvas.SetLeft(ellipse, pt.Position.X);
                    Canvas.SetTop(ellipse, pt.Position.Y);
                }
            }
        }
    }
}