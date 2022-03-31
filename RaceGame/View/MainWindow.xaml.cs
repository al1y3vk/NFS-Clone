using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using HomeWork5;
using HomeWork5.RaceModel;
using Microsoft.Win32;

namespace RaceGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public List<string> musicList { get; set; } = new List<string>();
        public MainWindow()
        {
            string directorypath = "..\\..\\..\\music";
            List<string> musicPath = Directory.GetFiles(directorypath).ToList();
            musicPath.ForEach(m => musicList.Add(System.IO.Path.GetFileName(m)));
            InitializeComponent();
            MusicListBox.SelectedIndex = 0;
            mediaPlayer.Play();
            MenuPage menuPage = new MenuPage();
            MainFrame.NavigationService.Navigate(menuPage);
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void MusicListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                string MusicPath = $"..\\..\\..\\music\\{MusicListBox.SelectedItem as string}";
                mediaPlayer.Open(new Uri(System.IO.Path.GetFullPath(MusicPath)));
                mediaPlayer.Play();
        }
    }
}
