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
using Microsoft.Devices.Sensors;

namespace MovingRect
{
    public partial class MainPage : PhoneApplicationPage
    {
        Accelerometer accelerometer;
        double CanvasWidth;
        double CanvasHeight;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            accelerometer = new Accelerometer();
            accelerometer.ReadingChanged += new EventHandler<AccelerometerReadingEventArgs>(accelerometer_ReadingChanged);
        }

        void accelerometer_ReadingChanged(object sender, AccelerometerReadingEventArgs e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                // 가속도계를 이용해서 새로운 위치 계산
                double X = Canvas.GetLeft(myRect) + e.X * 30;
                double Y = Canvas.GetTop(myRect) - e.Y * 30;

                // Canvas 범위를 넘지 않도록 조정
                if (X < 0) X = 0;
                if (Y < 0) Y = 0;
                if (X + myRect.Width > CanvasWidth) 
                    X = CanvasWidth - myRect.Width;
                if (Y + myRect.Height > CanvasHeight) 
                    Y = CanvasHeight - myRect.Height;

                Canvas.SetLeft(myRect, X);
                Canvas.SetTop(myRect, Y);
            });
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Canvas의 실제 Width와 Height 얻기
            CanvasWidth = myCanvas.RenderSize.Width;
            CanvasHeight = myCanvas.RenderSize.Height;

            // 사각형의 초기 위치를 Canvas의 가운데로 지정
            Canvas.SetLeft(myRect, CanvasWidth / 2);
            Canvas.SetTop(myRect, CanvasHeight / 2);

            // 가속도계 센서 시작
            try
            {
                accelerometer.Start();
            }
            catch (AccelerometerFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}