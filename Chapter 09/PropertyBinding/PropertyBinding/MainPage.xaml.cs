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

namespace PropertyBinding
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // 데이터 초기화하기
            Musician musician = new Musician();
            musician.Name = "Pat Metheny";
            musician.Genre = "Jazz";

            // LayoutRoot Grid 컨트롤의 DataContext로 지정하기
            this.LayoutRoot.DataContext = musician;

        }
    }
}