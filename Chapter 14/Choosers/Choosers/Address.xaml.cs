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
    public partial class Address : PhoneApplicationPage
    {
        AddressChooserTask addressChooserTask;

        public Address()
        {
            InitializeComponent();

            addressChooserTask = new AddressChooserTask();
            addressChooserTask.Completed += new EventHandler<AddressResult>(addressChooserTask_Completed);
        }

        void addressChooserTask_Completed(object sender, AddressResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                txtAddress.Text = e.Address;
            }
        }

        private void btnGetAddress_Click(object sender, RoutedEventArgs e)
        {
            addressChooserTask.Show();
        }
    }
}