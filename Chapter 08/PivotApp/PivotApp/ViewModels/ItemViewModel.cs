using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PivotApp
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _song;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Song
        {
            get
            {
                return _song;
            }
            set
            {
                if (value != _song)
                {
                    _song = value;
                    NotifyPropertyChanged("Song");
                }
            }
        }

        private string _artist;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                if (value != _artist)
                {
                    _artist = value;
                    NotifyPropertyChanged("Artist");
                }
            }
        }

        private string _album;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Album
        {
            get
            {
                return _album;
            }
            set
            {
                if (value != _album)
                {
                    _album = value;
                    NotifyPropertyChanged("Album");
                }
            }
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