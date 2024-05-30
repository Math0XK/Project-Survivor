﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class SavedGameUi : BaseUi
    {
        internal TextBox playerName;
        internal Button btnBack;
        internal Button btnNext;
        internal Label lblNameDescription;
        internal Label lblTitle;

        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);
            playerName = new TextBox();
            playerName.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            playerName.Size = new Size(250, 0);
            playerName.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - playerName.Width / 2, uiManager.frmAppMain.grpMain.Height * 16 / 30);
            playerName.TabStop = false;
            uiManager.frmAppMain.grpMain.Controls.Add(playerName);

            lblNameDescription = new Label();
            lblNameDescription.Font = new Font(UiManager.customFont.Families[0], 18, FontStyle.Regular);
            lblNameDescription.Size = new Size(495, 32);
            lblNameDescription.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblNameDescription.Width / 2, uiManager.frmAppMain.grpMain.Height * 12 / 30);
            lblNameDescription.BackColor = Color.Transparent;
            lblNameDescription.ForeColor = Color.White;
            lblNameDescription.Text = "What was your survivor's name ?";
            lblNameDescription.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblNameDescription);

            lblTitle = new Label();
            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(388, 66);
            lblTitle.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblTitle.Width / 2, uiManager.frmAppMain.grpMain.Height * 4 / 30);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Load game";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);

            btnBack = new Button();
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

            btnNext = new Button();
            btnNext.Size = new Size(140, 80);
            btnNext.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnNext.Text = "Confirm";
            btnNext.ForeColor = Color.White;
            btnNext.TextAlign = ContentAlignment.MiddleCenter;
            btnNext.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2 - btnNext.Width / 2) * 24 / 20, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            //btnNext.MouseClick += BtnNext_MouseClick;
            btnNext.Click += BtnNext_Click;
            btnNext.GotFocus += GotFocus;
            btnNext.TabIndex = 0;
            uiManager.buttons.Add(btnNext);
            uiManager.frmAppMain.grpMain.Controls.Add(btnNext);
        }
        private void GotFocus(object sender, EventArgs e)
        {
            if(sender == btnNext)
            {
                btnNext.TabIndex = 1;
                btnBack.TabIndex = 0;
            }
            if(sender == btnBack)
            {
                btnBack.TabIndex = 1;
                btnNext.TabIndex = 0;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.frmAppMain.highScore = [0, 0, 0, 0, 0];
            uiManager.frmAppMain.pseudo = playerName.Text;
            if (uiManager.frmAppMain.saveManager.getFiles() == 1)
            {
                uiManager.frmAppMain.saveManager.ReadData();
                uiManager.ClearUi<SavedGameUi>();
                uiManager.frmAppMain.gameLayer = 7;
                uiManager.CreateUiComponents<ChooseDifficultyUi>();
            }
            else
            {
                MessageBox.Show("This survivor doesn't exist\n\nPlease, create a new save", "Survivor doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.ClearUi<SavedGameUi>();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.CreateUiComponents<MenuUi>();
        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            lblNameDescription.Dispose();
            lblTitle.Dispose();
            btnBack.Dispose();
            btnNext.Dispose();
            playerName.Dispose();
            uiManager.buttons.Clear();
        }

        /*private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.frmAppMain.pseudo = playerName.Text;
            if (uiManager.frmAppMain.saveManager.getFiles() == 1)
            {
                uiManager.frmAppMain.saveManager.ReadData();
                uiManager.ClearUi<SavedGameUi>();
                uiManager.frmAppMain.gameLayer = 7;
                uiManager.CreateUiComponents<ChooseDifficultyUi>();
            }
            else
            {
                MessageBox.Show("This survivor doesn't exist\n\nPlease, create a new save", "Survivor doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/

        /*private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.ClearUi<SavedGameUi>();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.CreateUiComponents<MenuUi>();
        }*/
    }
}
