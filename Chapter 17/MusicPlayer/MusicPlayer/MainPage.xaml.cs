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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System.Windows.Threading;
using System.IO;
using System.Windows.Media.Imaging;

namespace MusicPlayer
{
    public partial class MainPage : PhoneApplicationPage
    {
        MediaLibrary library;
        BitmapImage defaultAlbumImage;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            library = new MediaLibrary();
            listSong.ItemsSource = library.Songs;

            defaultAlbumImage = new BitmapImage();
            defaultAlbumImage.UriSource = new Uri("/ApplicationIcon.png", UriKind.Relative);
                

            MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(MediaPlayer_MediaStateChanged);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(33);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        
        void timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                FrameworkDispatcher.Update();
                txtTime.Text = MediaPlayer.PlayPosition.ToString();
            });
        }

        void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            txtStatus.Text = MediaPlayer.State.ToString();
            
         
        }

        private void listSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSong.Text = listSong.SelectedItem.ToString();
            MediaPlayer.Play(library.Songs[listSong.SelectedIndex]);
            
            Stream albumArtStream = library.Songs[listSong.SelectedIndex].Album.GetAlbumArt();
            if (albumArtStream != null)
            {
                BitmapImage albumArtImage = new BitmapImage();

                albumArtImage.SetSource(albumArtStream);
                imgAlbum.Source = albumArtImage;
            }
            else
            {
                imgAlbum.Source = defaultAlbumImage;
            }
        }

    }
}