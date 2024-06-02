using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class SettingsUi : BaseUi
    {
        TrackBar systemVolume = new();
        TrackBar musicVolume = new();
        TrackBar soundEffectsVolume = new();
        Button btnBack = new Button();
        Label lblTitle = new Label();
        Label lblSystemVolume = new Label();
        Label lblMusicVolume = new Label();
        Label lblSoundEffectsVolume = new Label();

        //Initiate all elements and display the Ui
        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);

            lblTitle = new();
            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(400, 66);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Text = "Settings";
            lblTitle.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblTitle.Width / 2, uiManager.frmAppMain.grpMain.Height * 4 / 30);
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);


            systemVolume.Minimum = 0;
            systemVolume.Maximum = 100;
            systemVolume.LargeChange = 1;
            systemVolume.Size = new Size(400, 25);
            systemVolume.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - systemVolume.Width / 2, uiManager.frmAppMain.grpMain.Height * 10 / 30);
            systemVolume.Value = (int)(uiManager.frmAppMain.soundManager.systemVolume * 100);
            systemVolume.ValueChanged += SystemVolume_ValueChanged;
            uiManager.frmAppMain.soundManager.isSystemVolumeChanged += SoundManager_isSystemVolumeChanged;
            uiManager.frmAppMain.grpMain.Controls.Add(systemVolume);

            lblSystemVolume.Size = new Size(400, 30);
            lblSystemVolume.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblSystemVolume.Text = "System Volume :"+ systemVolume.Value+"%";
            lblSystemVolume.BackColor = Color.Transparent;
            lblSystemVolume.ForeColor = Color.White;
            lblSystemVolume.TextAlign = ContentAlignment.TopCenter;
            lblSystemVolume.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblSystemVolume.Width / 2, uiManager.frmAppMain.grpMain.Height * 10 / 30 - systemVolume.Height);
            uiManager.frmAppMain.grpMain.Controls.Add(lblSystemVolume);

            musicVolume.Minimum = 0;
            musicVolume.Maximum = 100;
            musicVolume.LargeChange = 1;
            musicVolume.Size = new Size(400, 25);
            musicVolume.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - musicVolume.Width / 2, uiManager.frmAppMain.grpMain.Height * 15 / 30);
            musicVolume.Value = (int)(uiManager.frmAppMain.soundManager.musicVolume * 100);
            musicVolume.ValueChanged += MusicVolume_ValueChanged; ;
            uiManager.frmAppMain.grpMain.Controls.Add(musicVolume);

            lblMusicVolume.Size = new Size(400, 30);
            lblMusicVolume.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblMusicVolume.Text = "Music Volume :" + musicVolume.Value + "%";
            lblMusicVolume.BackColor = Color.Transparent;
            lblMusicVolume.ForeColor = Color.White;
            lblMusicVolume.TextAlign = ContentAlignment.TopCenter;
            lblMusicVolume.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblMusicVolume.Width / 2, uiManager.frmAppMain.grpMain.Height * 15 / 30 - musicVolume.Height);
            uiManager.frmAppMain.grpMain.Controls.Add(lblMusicVolume);

            soundEffectsVolume.Minimum = 0;
            soundEffectsVolume.Maximum = 100;
            soundEffectsVolume.LargeChange = 1;
            soundEffectsVolume.Size = new Size(400, 25);
            soundEffectsVolume.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - soundEffectsVolume.Width / 2, uiManager.frmAppMain.grpMain.Height * 20 / 30);
            soundEffectsVolume.Value = (int)(uiManager.frmAppMain.soundManager.soundEffectsVolume * 100);
            soundEffectsVolume.ValueChanged += SoundEffectsVolume_ValueChanged;
            uiManager.frmAppMain.grpMain.Controls.Add(soundEffectsVolume);

            lblSoundEffectsVolume.Size = new Size(500, 30);
            lblSoundEffectsVolume.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblSoundEffectsVolume.Text = "Sound effects Volume :" + soundEffectsVolume.Value + "%";
            lblSoundEffectsVolume.BackColor = Color.Transparent;
            lblSoundEffectsVolume.ForeColor = Color.White;
            lblSoundEffectsVolume.TextAlign = ContentAlignment.TopCenter;
            lblSoundEffectsVolume.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblSoundEffectsVolume.Width / 2, uiManager.frmAppMain.grpMain.Height * 20 / 30 - soundEffectsVolume.Height);
            uiManager.frmAppMain.grpMain.Controls.Add(lblSoundEffectsVolume);

            btnBack.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnBack.Size = new Size(140, 80);
            btnBack.ForeColor = Color.White;
            btnBack.Text = "Back";
            btnBack.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - btnBack.Width / 2, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            btnBack.Click += BtnBack_Click;
            
            btnBack.TabIndex = 0;
            uiManager.buttons.Add(btnBack);
            uiManager.frmAppMain.grpMain.Controls.Add(btnBack);

            if (uiManager.frmAppMain.cardMode)
            {
                btnBack.GotFocus += BtnBack_GotFocus;
                btnBack.LostFocus += BtnBack_LostFocus;
            }
        }
        //Change color to white when button lose focus
        private void BtnBack_LostFocus(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.White;
        }
        //Change color to green when the button get focus
        private void BtnBack_GotFocus(object sender, EventArgs e)
        {    
            btnBack.ForeColor = Color.ForestGreen;
        }
        //Event that occurs when the system volume value has changed
        private void SoundManager_isSystemVolumeChanged()
        {
            systemVolume.Value = (int)(uiManager.frmAppMain.soundManager.systemVolume * 100);
            lblSystemVolume.Text = "System Volume :" + systemVolume.Value + "%";
        }
        //Event that occurs when the back button is clicked
        private void BtnBack_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.ClearUi<SettingsUi>();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.CreateUiComponents<MenuUi>();
        }
        //Destroy all objects and clear the memory
        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);

            lblMusicVolume.Dispose();
            lblSoundEffectsVolume.Dispose();
            lblSystemVolume.Dispose();
            btnBack.Dispose();
            systemVolume.Dispose();
            soundEffectsVolume.Dispose();
            musicVolume.Dispose();
            lblTitle.Dispose();
            uiManager.buttons.Clear();
        }
        //Event that occurs when the trackbar value has changed
        private void SoundEffectsVolume_ValueChanged(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.soundEffectsVolume = (float)soundEffectsVolume.Value / 100;
            lblSoundEffectsVolume.Text = "Sound effects Volume :" + soundEffectsVolume.Value + "%";

        }
        //Event that occurs when the trackbar value has changed
        private void MusicVolume_ValueChanged(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.musicVolume = (float)musicVolume.Value / 100;
            lblMusicVolume.Text = "Music Volume :" + musicVolume.Value + "%";
            uiManager.frmAppMain.soundManager.pauseMusicLoop();
            uiManager.frmAppMain.soundManager.resumeMusicLoop();
        }
        //Event that occurs when the trackbar value has changed
        private void SystemVolume_ValueChanged(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.systemVolume = (float)systemVolume.Value/100;
            uiManager.frmAppMain.soundManager.pauseMusicLoop();
            uiManager.frmAppMain.soundManager.resumeMusicLoop();
            lblSystemVolume.Text = "System Volume :" + systemVolume.Value + "%";

        }
    }
}
