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


namespace MVVMBinding
{
    public class Student : INotifyPropertyChanged
    {
        // Property: StudentID
        private int _StudentID;
        public int StudentID 
        { 
            get { return _StudentID;}
            set
            {
                if (value != _StudentID)
                {
                    _StudentID = value;
                    NotifyPropertyChanged("StudentID");
                }
            }
        }

        // Property: Name
        private string _Name;
        public string Name 
        {
            get { return _Name; }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    NotifyPropertyChanged("Name");
                }
            } 
        }

        // Property : Age
        private int _Age;
        public int Age 
        {
            get { return _Age; }
            set
            {
                if (value != _Age)
                {
                    _Age = value;
                    NotifyPropertyChanged("Age");
                }
            } 
        }
   
        // Constructor
        public Student(int studentID, string name, int age)
        {
            StudentID = studentID;
            Name = name;
            Age = age;
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
