using ProjetVellemanTEST.GameEngine.UiManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjetVellemanTEST.GameEngine.SoundManager
{
    internal class SoundManager
    {
        internal string startupTheme = "Resources\\Shirobon-Hiraeth.wav";
        internal string easyTheme = "Resources\\Shirobon-Xilioh.wav";
        internal string mediumTheme = "Resources\\Shirobon-The-Chase.wav";
        internal string hardTheme = "Resources\\Shirobon-Vectors.wav";
        internal string harderTheme = "Resources\\Shirobon-Trident.wav";
        internal string demonTheme = "Resources\\Shirobon-Search-Unit.wav";
        internal string hitSoundEffect = "Resources\\hurt_c_08-102842.wav";
        internal string blastSoundEffect = "Resources\\8-bit-laser-151672.wav";
        internal string currentTheme;

        List<MediaPlayer> soundEffects = new List<MediaPlayer>();

        MediaPlayer theme = new();

        private frmAppMain frmAppMain;

        public SoundManager(frmAppMain frmAppMain)
        {
            this.frmAppMain = frmAppMain;
        }

        public void PlayMusicLoop(string fileName)
        {
            currentTheme = fileName;
            Play();
            
        }

        public void PlayGameMusic(string fileName)
        {
            theme.Volume = 1f;
            theme.Open(new("file:///" + new FileInfo(fileName).FullName));
            theme.Play();
            theme.MediaEnded += Theme_MediaEnded;
        }

        private void Theme_MediaEnded(object sender, EventArgs e)
        {
            frmAppMain.uiManager.win = true;
            frmAppMain.uiManager.CreateUiComponents<EndGameUi>();
        }

        internal void Play()
        {
            theme.Volume = 1f;
            theme.Open(new("file:///" + new FileInfo(currentTheme).FullName));
            theme.Play();
            Console.WriteLine("music");
            theme.MediaEnded += CurrentTheme_MediaEnded;
        }

        private void CurrentTheme_MediaEnded(object sender, EventArgs e)
        {
            theme.MediaEnded -= CurrentTheme_MediaEnded;
            theme.Close();
            Console.WriteLine("fin");
            Play();
        }

        public void StopMusicLoop() 
        {
            theme.MediaEnded -= CurrentTheme_MediaEnded;
            theme.Stop();
            theme.Close();
        }

        public void PlaySoundEffect(string fileName)
        {
            MediaPlayer soundEffect = new MediaPlayer();
            soundEffect = new();
            soundEffect.Volume = 1f;
            soundEffect.Open(new("file:///" + new FileInfo(fileName).FullName));
            soundEffects.Add(soundEffect);
            soundEffect.MediaEnded += StopSound;
            soundEffect.Play();


        }

        private void StopSound(object sender, EventArgs e)
        {
            List<MediaPlayer> copy = new List<MediaPlayer>(soundEffects);
            foreach(MediaPlayer soundEffect in copy)
            {
                if(sender == soundEffect)
                {
                    soundEffect.Close();
                    soundEffects.Remove(soundEffect);
                }
            }
        }
        internal void pauseMusicLoop()
        {
            theme.Pause();
        }
        internal void resumeMusicLoop()
        {
            theme.Play();
        }

    }
}
