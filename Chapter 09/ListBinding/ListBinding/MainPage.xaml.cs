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

namespace ListBinding
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Students students = new Students();
            students.Add(new Student(1, "김국사", 15));
            students.Add(new Student(2, "이영어", 16));
            students.Add(new Student(3, "박수학", 17));
            students.Add(new Student(4, "허미술", 14));

            this.listStudent.ItemsSource = students;
        }


    }
}