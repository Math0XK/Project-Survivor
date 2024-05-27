using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class PauseMenuUi : BaseUi
    {
        Panel pnlPauseMain = new();
        Button btnBack = new();
        Button btnRestart = new();
        Button btnResume = new();
        Label lblTitle = new();
        Label lblDescription = new();
        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);
            uiManager.frmAppMain.tmrGameUpdate.Stop();
            uiManager.frmAppMain.soundManager.pauseMusicLoop();

            pnlPauseMain.Size = new Size(uiManager.frmAppMain.grpMain.Width / 2, uiManager.frmAppMain.grpMain.Height / 2);
            pnlPauseMain.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - pnlPauseMain.Width / 2, uiManager.frmAppMain.grpMain.Height /2 - pnlPauseMain.Height / 2);
            pnlPauseMain.BackColor = Color.Black;
            pnlPauseMain.ForeColor = Color.White;
            pnlPauseMain.BorderStyle = BorderStyle.FixedSingle;
            uiManager.frmAppMain.grpMain.Controls.Add(pnlPauseMain);
            uiManager.frmAppMain.grpMain.Controls.SetChildIndex(pnlPauseMain, 0);


            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(388, 66);
            lblTitle.Location = new Point(pnlPauseMain.Width /2 - lblTitle.Width /2, 0);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Pause";
            lblTitle.TabIndex = 0;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnlPauseMain.Controls.Add(lblTitle);

            btnBack.Size = new Size(140, 80);
            btnBack.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnBack.Text = "Back to menu";
            btnBack.ForeColor = Color.White;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Location = new Point(pnlPauseMain.Width * 5 / 20 - btnBack.Width / 2, pnlPauseMain.Height - btnBack.Height  - 60);
            btnBack.MouseClick += BtnBack_MouseClick;
            pnlPauseMain.Controls.Add(btnBack);

            btnRestart.Size = new Size(140, 80);
            btnRestart.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnRestart.Text = "Restart";
            btnRestart.ForeColor = Color.White;
            btnRestart.TextAlign = ContentAlignment.MiddleCenter;
            btnRestart.Location = new Point(pnlPauseMain.Width / 2 - btnRestart.Width / 2, pnlPauseMain.Height - btnRestart.Height - 60);
            btnRestart.MouseClick += BtnRestart_MouseClick;
            pnlPauseMain.Controls.Add(btnRestart);


            btnResume.Size = new Size(140, 80);
            btnResume.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnResume.Text = "Resume";
            btnResume.ForeColor = Color.White;
            btnResume.TextAlign = ContentAlignment.MiddleCenter;
            btnResume.Location = new Point(pnlPauseMain.Width * 15 / 20  - btnResume.Width / 2, pnlPauseMain.Height - btnResume.Height - 60);
            btnResume.MouseClick += BtnResume_MouseClick;
            pnlPauseMain.Controls.Add(btnResume);

            lblDescription.Size = new Size(pnlPauseMain.Width, pnlPauseMain.Height - 200);
            lblDescription.Location = new Point(0, lblTitle.Height);
            lblDescription.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblDescription.Text = "The game has been paused\n\n\n If you quit the game, restart or go back to menu, the score will be lost";
            lblDescription.ForeColor = Color.White;
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            pnlPauseMain.Controls.Add(lblDescription);


        }

        private void BtnResume_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.ClearUi<PauseMenuUi>();
        }

        private void BtnRestart_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.frmAppMain.gameLayer = 1000;
            uiManager.frmAppMain.entityManager.clearAllEntity();
            uiManager.frmAppMain.hp = 8;
            uiManager.frmAppMain.mainCpt = 0;
            uiManager.frmAppMain.score = 0;
            uiManager.ClearUi<PauseMenuUi>();
            uiManager.frmAppMain.gameLayer = 999;
            uiManager.frmAppMain.soundManager.StopMusicLoop();
            switch (uiManager.mode)
            {
                case 1: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.easyTheme); uiManager.frmAppMain.endGameCpt = 10891; break;
                case 2: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.mediumTheme); uiManager.frmAppMain.endGameCpt = 11630; break;
                case 3: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.hardTheme); uiManager.frmAppMain.endGameCpt = 13663; break;
                case 4: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.harderTheme); uiManager.frmAppMain.endGameCpt = 12941; break;
                case 5: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.demonTheme); uiManager.frmAppMain.endGameCpt = 12197; break;
            }


        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.frmAppMain.score = 0;
            uiManager.frmAppMain.mainCpt = 0;
            uiManager.frmAppMain.hp = 8;
            uiManager.frmAppMain.entityManager.clearAllEntity();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.frmAppMain.soundManager.StopMusicLoop();
            uiManager.frmAppMain.soundManager.PlayMusicLoop(uiManager.frmAppMain.soundManager.startupTheme);
            uiManager.ClearUi<OnGameUi>();
            uiManager.ClearUi<PauseMenuUi>();
            uiManager.CreateUiComponents<MenuUi>();
        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            uiManager.frmAppMain.tmrGameUpdate.Start();
            uiManager.frmAppMain.soundManager.resumeMusicLoop();
            lblTitle.Dispose();
            btnBack.Dispose();
            btnRestart.Dispose();
            btnResume.Dispose();
            lblDescription.Dispose();
            pnlPauseMain.Dispose();
        }
    }
}
