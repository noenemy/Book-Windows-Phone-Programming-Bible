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

namespace Controls
{
    public partial class ListBox : PhoneApplicationPage
    {
        public ListBox()
        {
            InitializeComponent();
        }

        private void listArtists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ListBoxItem item in listArtists.SelectedItems)
            {
                if (item.Content.ToString() == "밥 딜런")
                {
                    MessageBox.Show(item.Content.ToString() + "은 비틀즈 멤버가 아닙니다.");
                    listArtists.SelectedItems.Remove(item);
                    return;
                }
            }            
        }
    }
}