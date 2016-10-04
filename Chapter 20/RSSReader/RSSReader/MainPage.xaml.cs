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
using System.Xml.Linq;

namespace RSSReader
{
    // 데이터바인딩에 사용될 클래스
    public class Post
    {
        // 속성
        public string Title { get; set; }  // 제목
        public string Author { get; set; }  // 글쓴이
        public string Link { get; set; }  // 본문 링크
        public string Category { get; set; }  // 분류
        public string PubDate { get; set; }  // 작성일

        // 생성자
        public Post(string title, string author, string link, string category, string pubDate)
        {
            Title = title;
            Author = author;
            Link = link;
            Category = category;
            PubDate = pubDate;

        }
    }

    // Post 클래스에 대한 컬렉션 클래스
    public class Posts : List<Post>
    {

    }

    public partial class MainPage : PhoneApplicationPage
    {
        Random rnd = new Random();
        Posts posts = new Posts();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // RSS 주소
            string strQuery = "http://noenemy.tistory.com/rss?rand=" + rnd.Next();

            // HttpWebRequest를 이용해서 비동기 방식으로 데이터 가져오기
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(strQuery));
            request.BeginGetResponse(new AsyncCallback(ReadCallback), request); 
        }

        private void ReadCallback(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);

            // 스트림으로부터 데이터를 읽기
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string strData = reader.ReadToEnd();
            reader.Close();
            stream.Close();

            // 데이터를 분석해서 화면에 출력한다.
            DisplayResult(strData);
        }

        // RSS 데이터를 파싱해서 Post 컬렉션을 구성하는 함수
        private void DisplayResult(string result)
        {

            XDocument doc = XDocument.Parse(result);
            var items = from item in doc.Descendants("item")
                           select new
                           {
                               // anonymous class 구성하기
                               Title = item.Element("title").Value,
                               Author = item.Element("author").Value,
                               Link = item.Element("link").Value,
                               Category = item.Element("category").Value,
                               PubDate = item.Element("pubDate").Value,
                           };

            // RSS 데이터를 이용해서 Post 컬렉션 구성하기
            foreach (var item in items)
            {
                Post post = new Post(item.Title, item.Author, item.Link, item.Category, item.PubDate);
                posts.Add(post);
            }

            // 리스트컨트롤에 데이터바인딩해서 화면에 출력
            Dispatcher.BeginInvoke(delegate()
            {
                listPosts.ItemsSource = posts;
            });
        }

    }
}