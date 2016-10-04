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
using Microsoft.Phone.Tasks;

namespace Launchers
{
    public partial class PhoneCall : PhoneApplicationPage
    {
        public PhoneCall()
        {
            InitializeComponent();
        }

        private void btnCall_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();            
            phoneCallTask.DisplayName = txtDisplayName.Text;
            phoneCallTask.PhoneNumber = txtPhoneNumber.Text;
            phoneCallTask.Show();

        }
    }
}