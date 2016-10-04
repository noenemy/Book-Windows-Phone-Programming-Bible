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
using System.Threading;
using System.IO;
using System.IO.IsolatedStorage;

namespace AppState
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool newPageInstance = false;
        private string pageData = "";

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            newPageInstance = true;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (newPageInstance == false)
            {
                pageData = txtMemo.Text;
                (Application.Current as AppState.App).appData = pageData;
            }

        }
        

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            // 새로운 인스턴스의 페이지일 경우 저장된 데이터를 가져온다.
            // 새로운 인스턴스가 아닐 경우 메모리에 데이터가 이미 존재한다.
            if (newPageInstance)
            {

                // 애플리케이션 상태 정보가 없으면 읽어오도록 호출한다.
                if ((Application.Current as AppState.App).appData == null)
                {
                    GetDataAsync();
                }
                else
                {
                    // 애플리케이션 멤버 변수 값을 페이지 상태 값으로 지정하고 화면에 출력한다.
                    pageData = (Application.Current as AppState.App).appData;
                    txtMemo.Text = pageData;
                }
            }

            // 새로운 페이지 인스턴스가 아님을 설정한다.
            // 생성자가 다시 호출되면 이 값이 true로 설정된다.
            newPageInstance = false;
        }


        // OnNavigatedTo 이벤트 핸들러에서 호출된다.
        // 데이터를 비동기적으로 가져오기 위해 새로운 쓰레드를 생성하고 GetData를 호출한다.
        public void GetDataAsync()
        {
            // 데이터가 로딩 중임을 알리기 위해 ProgressBar를 보여준다.
            progressLoading.Visibility = System.Windows.Visibility.Visible;

            // 새로운 쓰레드에서 GetData 메소드를 호출한다..
            Thread threadGetData = new Thread(new ThreadStart(GetData));
            threadGetData.Start();

        }

        // 별도의 쓰레드에서 데이터를 가져오는 함수
        public void GetData()
        {
            string data = "";

            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isoStore.FileExists("myMemo.txt"))
            {
                // 격리저장소에 저장된 애플리케이션 상태 정보를 읽는다.
                StreamReader reader = new StreamReader(isoStore.OpenFile("myMemo.txt", FileMode.Open));
                data = reader.ReadToEnd();
                reader.Close();


            }
            // UI 쓰레드에서 읽은 정보를 반영하도록 SetData 함수를 호출한다.
            Dispatcher.BeginInvoke(() => { SetData(data); });
        }

        // UI 쓰레드에서 호출되는 함수
        public void SetData(string data)
        {
            pageData = data;

            // 사용자에게 상태 정보를 출력한다.
            txtMemo.Text = pageData;

            // 페이지 상태 정보를 애플리케이션 레벨의 appData 멤버 변수에 반영한다.
            (Application.Current as AppState.App).appData = pageData;

            progressLoading.Visibility = System.Windows.Visibility.Collapsed;
            
        }



    }
}