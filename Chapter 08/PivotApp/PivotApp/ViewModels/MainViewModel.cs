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


namespace PivotApp
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
            this.Items.Add(new ItemViewModel() { Song = "James", Artist = "PAT METHENY", Album = "Offramp" });
            this.Items.Add(new ItemViewModel() { Song = "Do I Need A Reason", Artist = "D'SOUND", Album = "My Today" });
            this.Items.Add(new ItemViewModel() { Song = "거리의 악사", Artist = "봄여름가을겨울", Album = "1집" });
            this.Items.Add(new ItemViewModel() { Song = "Eclipse", Artist = "PINK FLOYD", Album = "The Dark Side Of The Moon" });
            this.Items.Add(new ItemViewModel() { Song = "Don't Know Why", Artist = "NORAH JONES", Album = "Come Away With Me" });
            this.Items.Add(new ItemViewModel() { Song = "발해를 꿈꾸며", Artist = "서태지와아이들", Album = "3집" });
            this.Items.Add(new ItemViewModel() { Song = "Come As You Are", Artist = "NIRVANA", Album = "Nevermind" });
            this.Items.Add(new ItemViewModel() { Song = "Vertigo", Artist = "U2", Album = "How To Dismantle An Atomic Bomb" });

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