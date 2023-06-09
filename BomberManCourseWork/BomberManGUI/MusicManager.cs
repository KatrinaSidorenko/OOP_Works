using AxWMPLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BomberManGUI
{
    // Зберігає, посилання до файлів із звуковими ефектами, що потім використовуються у фоновомі режимі процесу гри та під час вибуху бомб
    public static class MusicManager
    {
        private static string _bombSoundPath = _bombSoundPath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bomb_sound.wav");

        public static void BombSoundPlay()
        {
            try
            {
                var player = new SoundPlayer(_bombSoundPath);
                player.Play();
            }
            catch 
            {
                throw new Exception("Failed to play bomb sound");
            }
            
        }

        public static void BackgroundSoundPlay(AxWindowsMediaPlayer player)
        {
            player.URL = @"background_music.wav";
            player.settings.playCount = 9999;
            player.Ctlcontrols.play();
            player.Visible = false;
        }

    }
}
