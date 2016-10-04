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
    public partial class EmailAddress : PhoneApplicationPage
    {
        EmailAddressChooserTask emailAddressChooserTask;

        public EmailAddress()
        {
            InitializeComponent();

            emailAddressChooserTask = new EmailAddressChooserTask();
            emailAddressChooserTask.Completed += new EventHandler<EmailResult>(emailAddressChooserTask_Completed);
        }

        void emailAddressChooserTask_Completed(object sender, EmailResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                txtEmail.Text = e.Email;
            }
        }

        private void btnGetEmailAddress_Click(object sender, RoutedEventArgs e)
        {
            emailAddressChooserTask.Show();
        }
    }
}