using ProjetVellemanTEST.GameEngine.SoundManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class ChooseDifficultyUi : BaseUi
    {
        Button btnEasyMode = new();
        Button btnMediumMode = new();
        Button btnHardMode = new();
        Button btnHarderMode = new();
        Button btnDemonMode = new();
        Button btnBack = new();
        Button btnNext = new();
        Label lblModeDescription = new();
        Label lblTitle = new();

        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);

            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(800, 66);
            lblTitle.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblTitle.Width / 2, uiManager.frmAppMain.grpMain.Height * 4 / 30);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Select the level";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);

            btnBack.Size = new Size(140, 80);
            btnBack.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnBack.Text = "Back";
            btnBack.ForeColor = Color.White;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2 - btnBack.Width / 2) * 16 / 20, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            //btnBack.MouseClick += BtnBack_MouseClick;
            btnBack.Click += BtnBack_Click;
            btnBack.GotFocus += GotFocus;
            btnBack.TabIndex = 1;
            uiManager.buttons.Add(btnBack);
            uiManager.frmAppMain.grpMain.Controls.Add(btnBack);

            btnNext.Size = new Size(140, 80);
            btnNext.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnNext.Text = "Confirm";
            btnNext.ForeColor = Color.White;
            btnNext.TextAlign = ContentAlignment.MiddleCenter;
            btnNext.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2 - btnNext.Width / 2) * 24 / 20, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            //btnNext.MouseClick += BtnNext_MouseClick;
            btnNext.Click += BtnNext_Click;
            btnNext.GotFocus += GotFocus;
            btnNext.TabIndex = 1;
            uiManager.buttons.Add(btnNext);
            uiManager.frmAppMain.grpMain.Controls.Add(btnNext);

            btnEasyMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnEasyMode.Size = new Size(140, 80);
            btnEasyMode.ForeColor = Color.White;
            btnEasyMode.Text = "Easy";
            btnEasyMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnEasyMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 8 / 30);
            //btnEasyMode.MouseClick += UpdateLabel;
            btnEasyMode.Click += UpdateLabel;
            btnEasyMode.GotFocus += GotFocus;
            btnEasyMode.TabIndex = 0;
            uiManager.buttons.Add(btnEasyMode);
            uiManager.frmAppMain.grpMain.Controls.Add((btnEasyMode));

            btnMediumMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnMediumMode.Size = new Size(140, 80);
            btnMediumMode.ForeColor = Color.White;
            btnMediumMode.Text = "Medium";
            btnMediumMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnMediumMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 11 / 30);
            //btnMediumMode.MouseClick += UpdateLabel;
            btnMediumMode.Click += UpdateLabel;
            btnMediumMode.GotFocus += GotFocus;
            btnMediumMode.TabIndex = 1;
            uiManager.buttons.Add(btnMediumMode);
            uiManager.frmAppMain.grpMain.Controls.Add((btnMediumMode));

            btnHardMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnHardMode.Size = new Size(140, 80);
            btnHardMode.ForeColor = Color.White;
            btnHardMode.Text = "Hard";
            btnHardMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnHardMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 14 / 30);
            //btnHardMode.MouseClick += UpdateLabel;
            btnHardMode.Click += UpdateLabel;
            btnHardMode.GotFocus += GotFocus;
            btnHardMode.TabIndex = 1;
            uiManager.buttons.Add(btnHardMode);
            uiManager.frmAppMain.grpMain.Controls.Add((btnHardMode));

            btnHarderMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnHarderMode.Size = new Size(140, 80);
            btnHarderMode.ForeColor = Color.White;
            btnHarderMode.Text = "Harder";
            btnHarderMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnHarderMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 17 / 30);
            //btnHarderMode.MouseClick += UpdateLabel;
            btnHarderMode.Click += UpdateLabel;
            btnHarderMode.GotFocus += GotFocus;
            btnHarderMode.TabIndex = 1;
            uiManager.buttons.Add(btnHarderMode);
            uiManager.frmAppMain.grpMain.Controls.Add((btnHarderMode));

            btnDemonMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnDemonMode.Size = new Size(140, 80);
            btnDemonMode.ForeColor = Color.White;
            btnDemonMode.Text = "Demon";
            btnDemonMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnDemonMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 20 / 30);
            //btnDemonMode.MouseClick += UpdateLabel;
            btnDemonMode.Click += UpdateLabel;
            btnDemonMode.GotFocus += GotFocus;
            btnDemonMode.TabIndex = 1;
            uiManager.buttons.Add(btnDemonMode);
            uiManager.frmAppMain.grpMain.Controls.Add((btnDemonMode));

            lblModeDescription.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblModeDescription.Size = new Size(800, 420);
            lblModeDescription.ForeColor = Color.White;
            lblModeDescription.BackColor = Color.Transparent;
            lblModeDescription.Text = "Mode_Description";
            lblModeDescription.Location = new Point(uiManager.frmAppMain.grpMain.Width * 3 / 4 - lblModeDescription.Width / 2, uiManager.frmAppMain.grpMain.Height * 8 / 30);
            uiManager.frmAppMain.grpMain.Controls.Add(lblModeDescription);
        }

        private void GotFocus(object sender, EventArgs e)
        {
            if(sender == btnEasyMode)
            {
                btnEasyMode.TabIndex = 1;
                btnMediumMode.TabIndex = 0;
            }
            if(sender == btnMediumMode)
            {
                btnMediumMode.TabIndex = 1;
                btnHardMode.TabIndex = 0;
            }
            if(sender == btnHardMode)
            {
                btnHardMode.TabIndex = 1;
                btnHarderMode.TabIndex = 0;
            }
            if(sender == btnHarderMode)
            {
                btnHarderMode.TabIndex = 1;
                btnDemonMode.TabIndex = 0;
            }
            if(sender == btnDemonMode)
            {
                btnDemonMode.TabIndex = 1;
                btnNext.TabIndex = 0;
            }
            if(sender == btnNext)
            {
                btnNext.TabIndex = 1;
                btnBack.TabIndex = 0;
            }
            if(sender == btnBack)
            {
                btnBack.TabIndex = 1;
                btnEasyMode.TabIndex = 0;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            if (uiManager.mode == 0)
            {
                MessageBox.Show("No level selected, please select a level", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (uiManager.mode < 0 || uiManager.mode > 5)
            {
                MessageBox.Show("Oups, something went wrong with the level", "Seletion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                uiManager.ClearUi<ChooseDifficultyUi>();
                uiManager.frmAppMain.gameLayer = 999;
                uiManager.CreateUiComponents<OnGameUi>();
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
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            uiManager.ClearUi<ChooseDifficultyUi>();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.CreateUiComponents<MenuUi>();
        }
        private void UpdateLabel(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            if (sender == btnEasyMode)
            {
                lblModeDescription.Text = "EasyMode_Description";
                uiManager.mode = 1;
            }
            else if (sender == btnMediumMode)
            {
                lblModeDescription.Text = "MeduimMode_Description";
                uiManager.mode = 2;
            }
            else if (sender == btnHardMode)
            {
                lblModeDescription.Text = "HardMode_Description";
                uiManager.mode = 3;
            }
            else if (sender == btnHarderMode)
            {
                lblModeDescription.Text = "HarderMode_Description";
                uiManager.mode = 4;
            }
            else if (sender == btnDemonMode)
            {
                lblModeDescription.Text = "DemonMode_Description";
                uiManager.mode = 5;
            }
        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            btnBack.Dispose();
            btnNext.Dispose();
            btnEasyMode.Dispose();
            btnMediumMode.Dispose();
            btnHardMode.Dispose();
            btnHarderMode.Dispose();
            btnDemonMode.Dispose();
            lblTitle.Dispose();
            lblModeDescription.Dispose();
            uiManager.buttons.Clear();
        }

        /*private void UpdateLabel(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            if (sender == btnEasyMode)
            {
                lblModeDescription.Text = "EasyMode_Description";
                uiManager.mode = 1;
            }
            else if(sender == btnMediumMode)
            {
                lblModeDescription.Text = "MeduimMode_Description";
                uiManager.mode = 2;
            }
            else if(sender == btnHardMode)
            {
                lblModeDescription.Text = "HardMode_Description";
                uiManager.mode = 3;
            }
            else if (sender == btnHarderMode)
            {
                lblModeDescription.Text = "HarderMode_Description";
                uiManager.mode = 4;
            }
            else if (sender == btnDemonMode)
            {
                lblModeDescription.Text = "DemonMode_Description";
                uiManager.mode = 5;
            }
        }*/

        /*private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            if(uiManager.mode == 0)
            {
                MessageBox.Show("No level selected, please select a level", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(uiManager.mode < 0 || uiManager.mode > 5)
            {
                MessageBox.Show("Oups, something went wrong with the level", "Seletion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                uiManager.ClearUi<ChooseDifficultyUi>();
                uiManager.frmAppMain.gameLayer = 999;
                uiManager.CreateUiComponents<OnGameUi>();
                uiManager.frmAppMain.soundManager.StopMusicLoop();
                switch(uiManager.mode)
                {
                    case 1: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.easyTheme); uiManager.frmAppMain.endGameCpt = 10891; break;
                    case 2: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.mediumTheme); uiManager.frmAppMain.endGameCpt = 11630; break;
                    case 3: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.hardTheme); uiManager.frmAppMain.endGameCpt = 13663; break;
                    case 4: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.harderTheme); uiManager.frmAppMain.endGameCpt = 12941; break;
                    case 5: uiManager.frmAppMain.soundManager.PlayGameMusic(uiManager.frmAppMain.soundManager.demonTheme); uiManager.frmAppMain.endGameCpt = 12197; break;
                }
            }
            
        }*/

        /*private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            uiManager.ClearUi<ChooseDifficultyUi>();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.CreateUiComponents<MenuUi>();
            
        }*/
    }
}
