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
        internal string hurtSoundEffect = "Resources\\hurt_c_08-102842.wav";
        internal string blastSoundEffect = "Resources\\8-bit-laser-151672.wav";
        internal string winSoundEffect = "Resources\\good-6081.wav";
        internal string gameOverSoundEffect = "Resources\\game-over-arcade-6435.wav";
        internal string clickSoundEffect = "Resources\\click-151673.wav";
        internal string hitSoundEffect = "Resources\\gameboy-pluck-41265.wav";
        internal string currentTheme;
        internal float systemVolume = 1f;
        internal float musicVolume = 1f;
        internal float soundEffectsVolume = 1f;

        List<MediaPlayer> soundEffects = new List<MediaPlayer>();

        MediaPlayer theme = new();

        private frmAppMain frmAppMain;

        public SoundManager(frmAppMain frmAppMain)
        {
            this.frmAppMain = frmAppMain;
        }
        /// <summary>
        /// Play music loop
        /// </summary>
        /// <param name="fileName"></param>
        public void PlayMusicLoop(string fileName)
        {
            currentTheme = fileName;
            Play();
            
        }
        /// <summary>
        /// Play level music
        /// </summary>
        /// <param name="fileName"></param>
        public void PlayGameMusic(string fileName)
        {  
            theme.Open(new("file:///" + new FileInfo(fileName).FullName));
            theme.Volume = musicVolume * systemVolume;
            theme.Play();
            theme.MediaEnded += Theme_MediaEnded;
        }
        /// <summary>
        /// Event that occurs when level music end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Theme_MediaEnded(object sender, EventArgs e)
        {
            theme.MediaEnded -= Theme_MediaEnded;
            frmAppMain.uiManager.win = true;
            frmAppMain.uiManager.CreateUiComponents<EndGameUi>();
        }
        /// <summary>
        /// Play music
        /// </summary>
        internal void Play()
        {
            theme.Volume = musicVolume * systemVolume;
            theme.Open(new("file:///" + new FileInfo(currentTheme).FullName));
            theme.Play();
            theme.MediaEnded += CurrentTheme_MediaEnded;
        }
        /// <summary>
        /// Event that occurs when music has stopped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentTheme_MediaEnded(object sender, EventArgs e)
        {
            theme.MediaEnded -= CurrentTheme_MediaEnded;
            theme.Close();
            Play();
        }
        /// <summary>
        /// Stop music loop
        /// </summary>
        public void StopMusicLoop() 
        {
            theme.MediaEnded -= CurrentTheme_MediaEnded;
            theme.MediaEnded -= Theme_MediaEnded;
            theme.Stop();
            theme.Close();
        }
        /// <summary>
        /// Play soundeffect
        /// </summary>
        /// <param name="fileName"></param>
        public void PlaySoundEffect(string fileName)
        {
            MediaPlayer soundEffect = new MediaPlayer();
            soundEffect = new();
            soundEffect.Volume = soundEffectsVolume * systemVolume;
            soundEffect.Open(new("file:///" + new FileInfo(fileName).FullName));
            soundEffects.Add(soundEffect);
            soundEffect.MediaEnded += StopSound;
            soundEffect.Play();


        }
        /// <summary>
        /// Stop and unload the soundeffect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Pause music
        /// </summary>
        internal void pauseMusicLoop()
        {
            theme.Pause();
        }
        //Resume the music
        internal void resumeMusicLoop()
        {
            theme.Volume = musicVolume * systemVolume;
            theme.Play();
        }

        /// <summary>
        /// Manage event related to the change of the system volume value
        /// </summary>
        public delegate void SystemVolumeChanged();
        public event SystemVolumeChanged isSystemVolumeChanged;

        public void SystemVolumeChange()
        {
            if (theme.Volume != musicVolume*systemVolume && !frmAppMain.paused)
            {
                isSystemVolumeChanged?.Invoke();
            }
        }

    }
}
