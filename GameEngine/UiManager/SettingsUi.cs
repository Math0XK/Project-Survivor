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

        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);

            //musicVolume.Value = (int)(uiManager.frmAppMain.soundManager.musicVolume*100);
            //soundEffectsVolume.Value = (int)(uiManager.frmAppMain.soundManager.soundEffectsVolume*100);

            systemVolume.Minimum = 0;
            systemVolume.Maximum = 100;
            systemVolume.LargeChange = 1;
            systemVolume.Size = new Size(400, 25);
            systemVolume.Location = new Point(uiManager.frmAppMain.grpMain.Width, 50);
            systemVolume.Value = (int)(uiManager.frmAppMain.soundManager.systemVolume * 100);
            systemVolume.ValueChanged += SystemVolume_ValueChanged;
            uiManager.frmAppMain.grpMain.Controls.Add(systemVolume);

            btnBack.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnBack.Size = new Size(140, 80);
            btnBack.ForeColor = Color.White;
            btnBack.Text = "Back";
            btnBack.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - btnBack.Width / 2, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            btnBack.MouseClick += BtnBack_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnBack);
        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void SystemVolume_ValueChanged(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.systemVolume = (float)systemVolume.Value/100;
            uiManager.frmAppMain.soundManager.pauseMusicLoop();
            uiManager.frmAppMain.soundManager.resumeMusicLoop();
        }
    }
}
