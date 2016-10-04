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

namespace TouchTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        private TransformGroup transformGroup;
        private TranslateTransform translationTransform;
        private ScaleTransform scaleTransform;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            transformGroup = new TransformGroup();
            translationTransform = new TranslateTransform();
            scaleTransform = new ScaleTransform();

            transformGroup.Children.Add(translationTransform);
            transformGroup.Children.Add(scaleTransform);
            myRect.RenderTransform = transformGroup;


            this.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(MainPage_ManipulationStarted);
            this.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(MainPage_ManipulationDelta);
            this.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(MainPage_ManipulationCompleted);
        }

        void MainPage_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            txtStatus.Text = "ManipulationCompleted";
        }

        void MainPage_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            txtStatus.Text = "ManipulationDelta";

            // 사각형 위치 변경
            translationTransform.X += e.DeltaManipulation.Translation.X;
            translationTransform.Y += e.DeltaManipulation.Translation.Y;

            // 사각형 크기 변경
            if (e.DeltaManipulation.Scale.X > 0)
                scaleTransform.ScaleX *= e.DeltaManipulation.Scale.X;
            if (e.DeltaManipulation.Scale.Y > 0)
                scaleTransform.ScaleY *= e.DeltaManipulation.Scale.Y;
        }

        void MainPage_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            txtStatus.Text = "ManipulationStarted";
        }
    }
}