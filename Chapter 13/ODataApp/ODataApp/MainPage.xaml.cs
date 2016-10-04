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
using System.Data.Services.Client;
using ODataApp.Northwind;

namespace ODataApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 데이터서비스 객체와 URI 선언
        private DataServiceContext northwind;
        private readonly Uri northwindUri =
            new Uri("http://services.odata.org/Northwind/Northwind.svc/");
        private DataServiceCollection<Product> products;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnShowList_Click(object sender, RoutedEventArgs e)
        {
            // 컨텍스트와 바인딩 컬렉션 초기화하기 
            NorthwindEntities context = new NorthwindEntities(northwindUri);
            products = new DataServiceCollection<Product>(context);

            // Products 테이블 쿼리하기
            var query = from product in context.Products
                        select product;

            // LoadCompleted 이벤트 핸들러 등록
            products.LoadCompleted += new EventHandler<LoadCompletedEventArgs>(products_LoadCompleted);

            // LINQ 쿼리 실행
            products.LoadAsync(query);
        }

        void products_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                // 로드할 데이터 페이지가 더 있는지 확인
                if (products.Continuation != null)
                {
                    // 다음 페이지 읽기
                    products.LoadNextPartialSetAsync();
                }
                else
                {
                    // ListBox에 데이터 바인딩하기
                    listProduct.ItemsSource = products;
                }
            }
            else
            {
                MessageBox.Show(string.Format("데이터를 가져올 수 없습니다. {0}", e.Error.Message));
            }
        }
    }
}