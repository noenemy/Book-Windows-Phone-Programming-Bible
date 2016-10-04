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
using System.IO;
using System.IO.IsolatedStorage;


namespace SimpleIO
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // 격리 저장소 얻기
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();

            // 데이터 저장할 폴더 생성하기
            store.CreateDirectory("Data");

            // StreamWriter를 이용해서 test.txt에 내용 저장하기
            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream("Data\\test.txt", FileMode.OpenOrCreate, store));
            writer.WriteLine(txtInput.Text);
            writer.Close();

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            // 격리 저장소 얻기
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();

            // StreamReader를 이용해서 파일 내용 읽기
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(new IsolatedStorageFileStream("Data\\test.txt", FileMode.Open, store));
                string data = reader.ReadLine();

                // 파일 내용을 읽어서 화면에 출력하기
                txtOutput.Text = data;
                reader.Close();
            }
            catch
            {
                MessageBox.Show("파일을 읽을 수 없습니다.");
            }

        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }
    }
}