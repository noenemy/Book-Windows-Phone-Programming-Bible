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
    public partial class SaveEmailAddress : PhoneApplicationPage
    {
        SaveEmailAddressTask saveEmailAddressTask;

        public SaveEmailAddress()
        {
            InitializeComponent();

            saveEmailAddressTask = new SaveEmailAddressTask();
            saveEmailAddressTask.Completed += new EventHandler<TaskEventArgs>(saveEmailAddressTask_Completed);
        }

        void saveEmailAddressTask_Completed(object sender, TaskEventArgs e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                MessageBox.Show("저장되었습니다.");
            }
            else
            {
                MessageBox.Show("취소되었습니다.");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmailAddress.Text.Trim().Length > 0)
            {
                saveEmailAddressTask.Email = txtEmailAddress.Text;
                saveEmailAddressTask.Show();
            }
            else
            {
                MessageBox.Show("메일주소를 입력하세요.");
                txtEmailAddress.Focus();
            }

        }
    }
}