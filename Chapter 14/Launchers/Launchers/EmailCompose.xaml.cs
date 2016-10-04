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
    public partial class EmailCompose : PhoneApplicationPage
    {
        public EmailCompose()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = txtTo.Text;
            emailComposeTask.Cc = txtCC.Text;
            emailComposeTask.Subject = txtSubject.Text;
            emailComposeTask.Body = txtBody.Text;
            emailComposeTask.Show();
        }
    }
}