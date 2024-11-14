using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using LibVLCSharp.Shared;
using System;
using System.Linq;

namespace LocalPlayer.Views
{
    public partial class MainView : UserControl
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        private bool _isPlaying = false;
        public MainView()
        {
            InitializeComponent();
            InitializePlayer();
#if DEBUG
            //this.AttachDevTools();
#endif
            var playPauseButton = this.FindControl<Button>("PlayPauseButton");
            playPauseButton.Click += PlayPauseButton_Click;
        }
        private void InitializePlayer()
        {
            Core.Initialize(); // Initialize LibVLCSharp

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            string mediaPath = "https://pagalfree.com/musics/128-Fear%20Song%20-%20Devara%20Part%201%20128%20Kbps.mp3";


            // Load the MP3 file (replace "Assets/song.mp3" with the actual path)
            var media = new Media(_libVLC, mediaPath, FromType.FromLocation);
            _mediaPlayer.Media = media;
        }

        private void PlayPauseButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _isPlaying = !_isPlaying;

            if (_isPlaying)
            {
                _mediaPlayer.Play(); // Start playback
                UpdatePlayPauseButton(true); // Set to pause icon
            }
            else
            {
                _mediaPlayer.Pause(); // Pause playback
                UpdatePlayPauseButton(false); // Set to play icon
            }
        }

        private void UpdatePlayPauseButton(bool isPlaying)
        {
            var playPauseButton = this.FindControl<Button>("PlayPauseButton");
            //if (isPlaying)
            //{
            //    playPauseButton.Content = new Path { Data = "M10,10 H18 V28 H10 Z M22,10 H30 V28 H22 Z", Fill = Brushes.White }; // Pause Icon
            //}
            //else
            //{
            //    playPauseButton.Content = new Path { Data = "M18,10 L18,28 34,18 Z", Fill = Brushes.White }; // Play Icon
            //}
        }
        

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}