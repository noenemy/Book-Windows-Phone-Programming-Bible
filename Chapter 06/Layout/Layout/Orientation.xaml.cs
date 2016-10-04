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

namespace Layout
{
    public partial class Orientation : PhoneApplicationPage
    {
        public Orientation()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            // portrait mode
            if ((e.Orientation & PageOrientation.Portrait) == (PageOrientation.Portrait))
            {
                System.Windows.Controls.Grid.SetRow(buttonList, 1);
                System.Windows.Controls.Grid.SetColumn(buttonList, 0);
            }            
            // landscape mode
            else
            {
                System.Windows.Controls.Grid.SetRow(buttonList, 0);
                System.Windows.Controls.Grid.SetColumn(buttonList, 1);
            }

        }
    }
}