using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace PanoramaApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() { LineOne = "N서울타워", LineTwo = "이태원&용산" });
            this.Items.Add(new ItemViewModel() { LineOne = "서울광장", LineTwo = "시청, 정동&덕수궁" });
            this.Items.Add(new ItemViewModel() { LineOne = "경복궁", LineTwo = "광화문" });
            this.Items.Add(new ItemViewModel() { LineOne = "광화문광장", LineTwo = "광화문,분수대" });
            this.Items.Add(new ItemViewModel() { LineOne = "덕수궁", LineTwo = "시청,정동&서울광장" });
            this.Items.Add(new ItemViewModel() { LineOne = "이태원거리", LineTwo = "이태원&용산" });
            this.Items.Add(new ItemViewModel() { LineOne = "63시티", LineTwo = "여의도,63빌딩" });
            this.Items.Add(new ItemViewModel() { LineOne = "코엑스", LineTwo = "삼성동" });

            this.IsDataLoaded = true;
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