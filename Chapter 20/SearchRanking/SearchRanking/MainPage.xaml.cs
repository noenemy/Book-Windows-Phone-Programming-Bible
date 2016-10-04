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
using System.Xml;
using System.IO;

namespace SearchRanking
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Naver에서 발급받은 개발자키를 등록해야 한다.
        string strKey = "";
        Random rnd = new Random();

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (strKey == "")
            {
                MessageBox.Show("네이버에서 발급 받은 개발자 키를 등록하세요.");
                return;
            }

            // 검색순위 정보를 제공하는 OpenAPI URL
            string strQuery = "http://openapi.naver.com/search?query=nexearch&target=rank&key=" + strKey + "&rand=" + rnd.Next();

            // WebClient를 이용해서 데이터 가져오기
            WebClient client = new System.Net.WebClient();
            client.OpenReadCompleted += new System.Net.OpenReadCompletedEventHandler(client_OpenReadCompleted);
            client.OpenReadAsync(new Uri(strQuery));

        }

        void client_OpenReadCompleted(object sender, System.Net.OpenReadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                // 스트림 데이터로 XmlReader 객체를 생성하고 "item" 요소를 찾는다.
                XmlReader reader = XmlReader.Create(e.Result);
                reader.ReadToFollowing("item");

                // UI 초기화
                listRanking.Items.Clear();
                txtLastUpdated.Text = "Last updated : " + DateTime.Now.ToString();

                while (reader.Read())
                {
                    // "R"로 시작하는 요소이면 (R1,R2,R3...)
                    if (reader.NodeType == XmlNodeType.Element && reader.Name.StartsWith("R") == true)
                    {
                        string K, S, V;
                        
                        // 노드 값에서 순위 데이터 값을 추출
                        string strRank = reader.Name.Substring(1);                                             

                        // Rn 요소의 하위 트리로 이동/
                        XmlReader item = reader.ReadSubtree();
                        
                        // "K" 요소로 이동한 후 K->S->V 순서로 데이터를 읽는다.                        
                        item.ReadToFollowing("K");                        
                        K = item.ReadElementContentAsString();
                        S = item.ReadElementContentAsString();
                        V = item.ReadElementContentAsString();
                        
                        // 리스트에 추가
                        listRanking.Items.Add( strRank + " " + K + " " + S + " " + V );

                    }

                }
                reader.Close();
            }
        }
    }
}