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

namespace Choosers
{
    public partial class PhoneNumber : PhoneApplicationPage
    {
        PhoneNumberChooserTask phoneNumberChooser;

        public PhoneNumber()
        {
            InitializeComponent();

            phoneNumberChooser = new PhoneNumberChooserTask();
            phoneNumberChooser.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooser_Completed);
        }

        void phoneNumberChooser_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                txtPhoneNumber.Text = e.PhoneNumber;
            }
        }

        private void btnGetPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            phoneNumberChooser.Show();
        }
    }
}