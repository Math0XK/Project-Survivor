using ProjetVellemanTEST.GameEngine.K8055DManager;
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
            //uiManager.frmAppMain.tmrGameUpdate.Stop();
            uiManager.frmAppMain.gameLayer = 998;
            uiManager.frmAppMain.soundManager.StopMusicLoop();

            pnlPauseMain.Size = new Size(uiManager.frmAppMain.grpMain.Width / 2, uiManager.frmAppMain.grpMain.Height / 2);
            pnlPauseMain.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - pnlPauseMain.Width / 2, uiManager.frmAppMain.grpMain.Height / 2 - pnlPauseMain.Height / 2);
            pnlPauseMain.BackColor = Color.Black;
            pnlPauseMain.ForeColor = Color.White;
            pnlPauseMain.BorderStyle = BorderStyle.FixedSingle;
            uiManager.frmAppMain.grpMain.Controls.Add(pnlPauseMain);
            uiManager.frmAppMain.grpMain.Controls.SetChildIndex(pnlPauseMain, 0);


            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(900, 66);
            lblTitle.Location = new Point(pnlPauseMain.Width / 2 - lblTitle.Width / 2, 0);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.TabIndex = 0;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnlPauseMain.Controls.Add(lblTitle);

            btnBack.Size = new Size(140, 80);
            btnBack.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnBack.Text = "Back to menu";
            btnBack.ForeColor = Color.White;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Location = new Point(pnlPauseMain.Width * 5 / 20 - btnBack.Width / 2, pnlPauseMain.Height - btnBack.Height - 60);
            //btnBack.MouseClick += BtnBack_MouseClick;
            btnBack.Click += BtnBack_Click;
            btnBack.TabIndex = 1;
            uiManager.buttons.Add(btnBack);
            pnlPauseMain.Controls.Add(btnBack);

            btnRestart.Size = new Size(140, 80);
            btnRestart.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnRestart.Text = "Restart";
            btnRestart.ForeColor = Color.White;
            btnRestart.TextAlign = ContentAlignment.MiddleCenter;
            btnRestart.Location = new Point(pnlPauseMain.Width / 2 - btnRestart.Width / 2, pnlPauseMain.Height - btnRestart.Height - 60);
            //btnRestart.MouseClick += BtnRestart_MouseClick;
            btnRestart.Click += BtnRestart_Click;
            btnRestart.TabIndex = 1;
            uiManager.buttons.Add(btnRestart);
            pnlPauseMain.Controls.Add(btnRestart);


            lblDescription.Size = new Size(pnlPauseMain.Width, pnlPauseMain.Height - 200);
            lblDescription.Location = new Point(0, lblTitle.Height);
            lblDescription.Font = new Font(UiManager.customFont.Families[0], 22, FontStyle.Regular);
            lblDescription.ForeColor = Color.White;
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            pnlPauseMain.Controls.Add(lblDescription);

            if (uiManager.frmAppMain.cardMode)
            {
                btnBack.GotFocus += GotFocus;
                btnRestart.GotFocus += GotFocus;
            }

            if (uiManager.frmAppMain.highScore[uiManager.mode - 1] < uiManager.frmAppMain.score)
            {
                uiManager.frmAppMain.highScore[uiManager.mode - 1] = uiManager.frmAppMain.score;
            }
            uiManager.frmAppMain.saveManager.WriteData();
            if (uiManager.win)
            {
                if (uiManager.frmAppMain.cardMode)
                {
                    Fctvm110.ClearAllDigital();
                }
                //uiManager.win = false;
                lblDescription.Text = "Survivor " + uiManager.frmAppMain.pseudo + " has succeed\n\n" + "Score : " + uiManager.frmAppMain.score + "\n" + "High score : " + uiManager.frmAppMain.highScore[uiManager.mode - 1];
                lblTitle.Text = "Level completed";
                uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.winSoundEffect);
                if (uiManager.mode != 5)
                {
                    btnNext.Size = new Size(140, 80);
                    btnNext.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
                    btnNext.ForeColor = Color.White;
                    btnNext.Text = "Next level";
                    btnNext.ForeColor = Color.White;
                    btnNext.TextAlign = ContentAlignment.MiddleCenter;
                    btnNext.Location = new Point(pnlPauseMain.Width * 15 / 20 - btnNext.Width / 2, pnlPauseMain.Height - btnNext.Height - 60);
                    //btnNext.MouseClick += BtnNext_MouseClick;
                    btnNext.Click += BtnNext_Click;
                    if (uiManager.frmAppMain.cardMode)
                    {
                        btnNext.GotFocus += GotFocus;
                    }
                    btnNext.TabIndex = 0;
                    uiManager.buttons.Add(btnNext);
                    pnlPauseMain.Controls.Add(btnNext);
                    pnlPauseMain.Controls.SetChildIndex(btnNext, 0);
                    pnlPauseMain.PerformLayout();
                }
            }
            else
            {
                lblDescription.Text = "Survivor " + uiManager.frmAppMain.pseudo + " hasn't survived\n\n" + "Score : " + uiManager.frmAppMain.score + "\n" + "High score : " + uiManager.frmAppMain.highScore[uiManager.mode - 1];
                lblTitle.Text = "Level failed";
                btnRestart.TabIndex = 0;
                uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.gameOverSoundEffect);
            }

        }
        private void GotFocus(object sender, EventArgs e)
        {
            if(sender == btnNext)
            {
                btnNext.TabIndex = 1;
                btnNext.ForeColor = Color.ForestGreen;
                btnBack.ForeColor = Color.White;
                btnRestart.TabIndex=0;
            }
            if(sender == btnRestart)
            {
                btnRestart.TabIndex = 1;
                btnRestart.ForeColor = Color.ForestGreen;
                if(uiManager.win && uiManager.mode < 5)
                {
                    btnNext.ForeColor= Color.White;
                }
                else btnBack.ForeColor = Color.White;
                btnBack.TabIndex = 0;
            }
            if(sender == btnBack && uiManager.win && uiManager.mode < 5)
            {
                btnBack.TabIndex = 1;
                btnBack.ForeColor = Color.ForestGreen;
                btnRestart.ForeColor = Color.White;
                btnNext.TabIndex = 0;
            }
            else if(sender == btnBack && (!uiManager.win || uiManager.mode == 5))
            {
                btnBack.TabIndex = 1;
                btnBack.ForeColor = Color.ForestGreen;
                btnRestart.ForeColor = Color.White;
                btnRestart.TabIndex = 0;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.frmAppMain.gameLayer = 1000;
            uiManager.frmAppMain.entityManager.clearAllEntity();
            uiManager.mode++;
            uiManager.frmAppMain.hp = 8;
            if (uiManager.frmAppMain.cardMode)
            {
                Fctvm110.ClearAnalogChannel(1);
                Fctvm110.SetAllDigital();
            }
            uiManager.frmAppMain.mainCpt = 0;
            uiManager.frmAppMain.score = 0;
            uiManager.ClearUi<EndGameUi>();
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

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.frmAppMain.gameLayer = 1000;
            uiManager.frmAppMain.entityManager.clearAllEntity();
            uiManager.frmAppMain.hp = 8;
            if (uiManager.frmAppMain.cardMode)
            {
                Fctvm110.ClearAnalogChannel(1);
                Fctvm110.SetAllDigital();
            }
            uiManager.frmAppMain.mainCpt = 0;
            uiManager.frmAppMain.score = 0;
            uiManager.ClearUi<EndGameUi>();
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            uiManager.ClearUi<OnGameUi>();
            uiManager.ClearUi<EndGameUi>();
            if (uiManager.frmAppMain.cardMode)
            {
                Fctvm110.ClearAnalogChannel(1);
                Fctvm110.ClearAllDigital();
            }
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            uiManager.mode = 0;
            uiManager.frmAppMain.score = 0;
            uiManager.frmAppMain.mainCpt = 0;
            uiManager.frmAppMain.hp = 8;
            uiManager.frmAppMain.entityManager.clearAllEntity();
            uiManager.frmAppMain.soundManager.StopMusicLoop();
            uiManager.frmAppMain.soundManager.PlayMusicLoop(uiManager.frmAppMain.soundManager.startupTheme);
            uiManager.CreateUiComponents<MenuUi>();
        }

        /*private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.frmAppMain.gameLayer = 1000;
            uiManager.frmAppMain.entityManager.clearAllEntity();
            uiManager.mode++;
            uiManager.frmAppMain.hp = 8;
            uiManager.frmAppMain.mainCpt = 0;
            uiManager.frmAppMain.score = 0;
            uiManager.ClearUi<EndGameUi>();
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
        }*/

        /*private void BtnRestart_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.frmAppMain.gameLayer = 1000;
            uiManager.frmAppMain.entityManager.clearAllEntity();
            uiManager.frmAppMain.hp = 8;
            uiManager.frmAppMain.mainCpt = 0;
            uiManager.frmAppMain.score = 0;
            uiManager.ClearUi<EndGameUi>();
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


        }*/

        /*private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.ClearUi<OnGameUi>();
            uiManager.ClearUi<EndGameUi>();
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            uiManager.mode = 0;
            uiManager.frmAppMain.score = 0;
            uiManager.frmAppMain.mainCpt = 0;
            uiManager.frmAppMain.hp = 8;
            uiManager.frmAppMain.entityManager.clearAllEntity();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.frmAppMain.soundManager.StopMusicLoop();
            uiManager.frmAppMain.soundManager.PlayMusicLoop(uiManager.frmAppMain.soundManager.startupTheme);
            uiManager.CreateUiComponents<MenuUi>();
        }*/

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            //uiManager.frmAppMain.tmrGameUpdate.Start();
            uiManager.win = false;
            uiManager.frmAppMain.soundManager.resumeMusicLoop();
            lblTitle.Dispose();
            btnBack.Dispose();
            btnRestart.Dispose();
            btnNext.Dispose();
            lblDescription.Dispose();
            pnlPauseMain.Dispose();
            uiManager.buttons.Clear();
        }
    }
}
