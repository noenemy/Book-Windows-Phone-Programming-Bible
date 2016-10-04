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
    public partial class SavePhoneNumber : PhoneApplicationPage
    {
        SavePhoneNumberTask savePhoneNumberTask;

        public SavePhoneNumber()
        {
            InitializeComponent();

            savePhoneNumberTask = new SavePhoneNumberTask();
            savePhoneNumberTask.Completed += new EventHandler<TaskEventArgs>(savePhoneNumberTask_Completed);
        }

        void savePhoneNumberTask_Completed(object sender, TaskEventArgs e)
        {
            if (e.TaskResult == TaskResult.OK)
                MessageBox.Show("저장되었습니다.");
            else
                MessageBox.Show("취소되었습니다.");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtPhoneNumber.Text.Trim().Length > 0)
            {
                savePhoneNumberTask.PhoneNumber = txtPhoneNumber.Text;
                savePhoneNumberTask.Show();
            }
            else
            {
                MessageBox.Show("전화번호를 입력하세요.");
                txtPhoneNumber.Focus();
            }

        }
    }
}