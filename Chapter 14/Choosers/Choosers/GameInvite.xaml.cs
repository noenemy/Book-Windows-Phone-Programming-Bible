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
    public partial class GameInvite : PhoneApplicationPage
    {
        GameInviteTask gameInviteTask;
        public GameInvite()
        {
            InitializeComponent();

            gameInviteTask = new GameInviteTask();
            gameInviteTask.Completed += new EventHandler<TaskEventArgs>(gameInviteTask_Completed);
        }

        void gameInviteTask_Completed(object sender, TaskEventArgs e)
        {
            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    MessageBox.Show("게임 초대가 전송 되었습니다.");
                    break;
                case TaskResult.Cancel:
                    MessageBox.Show("게임 초대가 사용자에 의해서 취소 되었습니다.");
                    break;
                case TaskResult.None:
                    MessageBox.Show("게임 초대를 전달하지 못했습니다.");
                    break;
            }

        }

        private void btnInvite_Click(object sender, RoutedEventArgs e)
        {
            gameInviteTask.SessionId = "MySessionID";
            gameInviteTask.Show();
        }
    }
}