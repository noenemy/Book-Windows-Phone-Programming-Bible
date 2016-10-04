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
using System.Collections.Generic;

namespace ListBinding
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(int studentID, string name, int age)
        {
            StudentID = studentID;
            Name = name;
            Age = age;
        }

    }

    public class Students : List<Student>
    {

    }
}
