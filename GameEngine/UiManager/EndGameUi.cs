using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class EndGameUi : BaseUi
    {
        Panel pnlPauseMain = new();
        Button btnBack = new();
        Button btnRestart = new();
        Button btnNext = new();
        Label lblTitle = new();
        Label lblDescription = new();
        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);
            uiManager.frmAppMain.tmrGameUpdate.Stop();
            uiManager.frmAppMain.soundManager.pauseMusicLoop();

            pnlPauseMain.Size = new Size(uiManager.frmAppMain.grpMain.Width / 2, uiManager.frmAppMain.grpMain.Height / 2);
            pnlPauseMain.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - pnlPauseMain.Width / 2, uiManager.frmAppMain.grpMain.Height / 2 - pnlPauseMain.Height / 2);
            pnlPauseMain.BackColor = Color.Black;
            pnlPauseMain.ForeColor = Color.White;
            pnlPauseMain.BorderStyle = BorderStyle.FixedSingle;
            uiManager.frmAppMain.grpMain.Controls.Add(pnlPauseMain);
            uiManager.frmAppMain.grpMain.Controls.SetChildIndex(pnlPauseMain, 0);


            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(388, 66);
            lblTitle.Location = new Point(pnlPauseMain.Width / 2 - lblTitle.Width / 2, 0);
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
            btnBack.Location = new Point(pnlPauseMain.Width * 5 / 20 - btnBack.Width / 2, pnlPauseMain.Height - btnBack.Height - 60);
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


            btnNext.Size = new Size(140, 80);
            btnNext.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnNext.Text = "Resume";
            btnNext.ForeColor = Color.White;
            btnNext.TextAlign = ContentAlignment.MiddleCenter;
            btnNext.Location = new Point(pnlPauseMain.Width * 15 / 20 - btnNext.Width / 2, pnlPauseMain.Height - btnNext.Height - 60);
            btnNext.MouseClick += BtnNext_MouseClick;
            pnlPauseMain.Controls.Add(btnNext);

            lblDescription.Size = new Size(pnlPauseMain.Width, pnlPauseMain.Height - 200);
            lblDescription.Location = new Point(0, lblTitle.Height);
            lblDescription.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblDescription.Text = "The game has been paused\n\n\n If you quit the game, restart or go back to menu, the score will be lost";
            lblDescription.ForeColor = Color.White;
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            pnlPauseMain.Controls.Add(lblDescription);
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnRestart_MouseClick(object sender, MouseEventArgs e)
        {
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
                case 1: uiManager.frmAppMain.soundManager.PlayMusicLoop(uiManager.frmAppMain.soundManager.easyTheme); break;
                case 2: uiManager.frmAppMain.soundManager.PlayMusicLoop(uiManager.frmAppMain.soundManager.mediumTheme); break;
                case 3: uiManager.frmAppMain.soundManager.PlayMusicLoop(uiManager.frmAppMain.soundManager.hardTheme); break;
                case 4: uiManager.frmAppMain.soundManager.PlayMusicLoop(uiManager.frmAppMain.soundManager.harderTheme); break;
                case 5: uiManager.frmAppMain.soundManager.PlayMusicLoop(uiManager.frmAppMain.soundManager.demonTheme); break;
            }


        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
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
            btnNext.Dispose();
            lblDescription.Dispose();
            pnlPauseMain.Dispose();
        }
    }
}
