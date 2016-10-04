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

namespace PageState
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool newPageInstance = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            newPageInstance = true;
        }

        // 페이지를 벗어날 때 페이지 상태 값 저장하는 함수
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SaveState(txtName);
            SaveState(radioMale);
            SaveState(radioFemale);
            SaveState(sliderAge);

            // 생성자가 다시 호출될 때 true로 설정된다.
            newPageInstance = false;

            // 페이지 상태 값이 저장되어 있음을 기록함
            this.State["PageStateSaved"] = true;
        }

        private void SaveState(TextBox textBox)
        {
            this.State[textBox.Name + "_Text"] = textBox.Text;
            this.State[textBox.Name + "_SelectionStart"] = textBox.SelectionStart;
            this.State[textBox.Name + "_SelectionLength"] = textBox.SelectionLength;

        }

        private void SaveState(RadioButton radioButton)
        {
            this.State[radioButton.Name + "_IsChecked"] = radioButton.IsChecked;
        }

        private void SaveState(Slider slider)
        {
            this.State[slider.Name + "_Value"] = slider.Value;
        }

        // 페이지로 돌아왔을 떄 페이지 상태정보가 있으면 복원하는 함수
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // 이전에 저장된 페이지 상태 정보가 있으면 복원한다.
            if (newPageInstance && this.State.ContainsKey("PageStateSaved") == true)
            {
                RestoreState(txtName);
                RestoreState(radioMale);
                RestoreState(radioFemale);
                RestoreState(sliderAge);


                this.State.Remove("PageStateSaved");
            }
        }
             

        private void RestoreState(TextBox textBox)
        {
            string key = textBox.Name + "_Text";
            string value = "";
            if (this.State.ContainsKey(key) == true)
            {
                textBox.Text = this.State[key].ToString();
            }
         
            key = textBox.Name + "_SelectionStart";
            if (this.State.ContainsKey(key) == true)
            {
                value = this.State[key].ToString();
                textBox.SelectionStart = Convert.ToInt32(value);
            }

            key = textBox.Name + "_SelectionLength";
            if (this.State.ContainsKey(key) == true)
            {
                value = this.State[key].ToString();
                textBox.SelectionLength = Convert.ToInt32(value);
            }
        }

        private void RestoreState(RadioButton radioButton)
        {
            string key = radioButton.Name + "_IsChecked";
            if (this.State.ContainsKey(key) == true)
            {
                string value = this.State[key].ToString();
                if (value.Length > 0)
                {
                    radioButton.IsChecked = Convert.ToBoolean(value);
                }
            }
        }

        private void RestoreState(Slider slider)
        {
            string key = slider.Name + "_Value";
            if (this.State.ContainsKey(key) == true)
            {
                string value = this.State[key].ToString();
                if (value.Length > 0)
                    slider.Value = Convert.ToDouble(value);
            }
        }

    }
}