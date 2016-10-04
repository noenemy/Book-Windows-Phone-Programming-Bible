using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MVVMBinding
{
    public class StudentViewModel
    {
        // Student 컬렉션
        public ObservableCollection<Student> Items { get; private set; }
        public bool IsDataLoaded { get; set; }

        public StudentViewModel()
        {
            // Student 컬렉션 초기화
            this.Items = new ObservableCollection<Student>();
            IsDataLoaded = false;
        }

        public void LoadData()
        {
            // Data 구성하기
            Items.Add(new Student(10, "스칼렛", 21));
            Items.Add(new Student(13, "무적기타", 29));
            Items.Add(new Student(18, "루크", 24));
            Items.Add(new Student(23, "재부리", 22));
            Items.Add(new Student(29, "민스프", 25));
            Items.Add(new Student(34, "원싱이", 23));
             
            IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
