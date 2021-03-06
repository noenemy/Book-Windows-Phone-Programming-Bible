﻿using System;
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

namespace MVVMBinding
{
    public partial class MainPage : PhoneApplicationPage
    {
        private StudentViewModel ViewModel = null;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            if (ViewModel == null)
                ViewModel = new StudentViewModel();
            DataContext = ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.ViewModel.IsDataLoaded == false)
            {
                this.ViewModel.LoadData();
            }
        }

    }
}