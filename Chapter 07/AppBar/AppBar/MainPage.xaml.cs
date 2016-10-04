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
using Microsoft.Phone.Shell;

namespace AppBar
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AppBar1.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ApplicationBarIconButton Clicked");
        }

        private void btnOpacity_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationBar.Opacity == 1)
                ApplicationBar.Opacity = 0.5;
            else
                ApplicationBar.Opacity = 1;
        }

        private void btnIsVisible_Click(object sender, RoutedEventArgs e)
        {
            ApplicationBar.IsVisible = !ApplicationBar.IsVisible;
        }

        private void btnIsMenuEnabled_Click(object sender, RoutedEventArgs e)
        {
            ApplicationBar.IsMenuEnabled = !ApplicationBar.IsMenuEnabled;
        }

        private void btnAddButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationBarIconButton newButton = new ApplicationBarIconButton();
            newButton.IconUri = new Uri("images/appbar.new.rest.png", UriKind.Relative);
            newButton.Text = "New Button";
            newButton.Click += new EventHandler(newButton_Click);
            
            ApplicationBar.Buttons.Add(newButton);
        }

        void newButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Button Clicked");
        }

        private void btnAddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ApplicationBarMenuItem newMenuItem = new ApplicationBarMenuItem();
            newMenuItem.Text = "New Menu Item";
            newMenuItem.Click += new EventHandler(newMenuItem_Click);

            ApplicationBar.MenuItems.Add(newMenuItem);
        }

        void newMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Menu Item Clicked");
        }

        private void ApplicationBarIconPrev_Click(object sender, EventArgs e)
        {
            MessageBox.Show("뒤로 갑니다.");
        }

        private void ApplicationBarIconNext_Click(object sender, EventArgs e)
        {
            MessageBox.Show("앞으로 갑니다.");
        }


        private void ApplicationBarMenuItemUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("위로 올라갑니다.");
        }

        private void ApplicationBarMenuItemDown_Click(object sender, EventArgs e)
        {
            MessageBox.Show("아래로 내려갑니다.");
        }




    } 
}