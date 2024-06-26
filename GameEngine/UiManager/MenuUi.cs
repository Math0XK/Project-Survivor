﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ProjetVellemanTEST.GameEngine.K8055DManager;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class MenuUi : BaseUi
    {
        Fctvm110 Fctvm110 = new Fctvm110();
        Button btnNewGame = new Button();
        Button btnSavedGame = new Button();
        Button btnSettings = new Button();
        Button btnCredits = new Button();
        Button btnQuit = new Button();
        Label lblTitle = new Label();

        /// <summary>
        /// Initiate all elements and display the Ui
        /// </summary>
        /// <param name="uiManager"></param>
        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);

            btnNewGame.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnNewGame.Text = "New Game";
            btnNewGame.TextAlign = ContentAlignment.MiddleCenter;
            btnNewGame.Size = new Size(140, 80);
            btnNewGame.ForeColor = Color.White;
            btnNewGame.TabIndex = 0;
            btnNewGame.Click += BtnNewGame_Click;
            btnNewGame.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnNewGame.Width / 2), (uiManager.frmAppMain.grpMain.Height * 8) / 30);
            uiManager.buttons.Add(btnNewGame);
            uiManager.frmAppMain.grpMain.Controls.Add(btnNewGame);

            btnSavedGame.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnSavedGame.Text = "Saved Game";
            btnSavedGame.TextAlign = ContentAlignment.MiddleCenter;
            btnSavedGame.Size = new Size(140, 80);
            btnSavedGame.ForeColor = Color.White;
            btnSavedGame.TabIndex = 1;
            btnSavedGame.Click += BtnSavedGame_Click;
            btnSavedGame.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnSavedGame.Width / 2), (uiManager.frmAppMain.grpMain.Height * 12) / 30);
            uiManager.buttons.Add(btnSavedGame);
            uiManager.frmAppMain.grpMain.Controls.Add(btnSavedGame);

            btnSettings.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleCenter;
            btnSettings.Size = new Size(140, 80);
            btnSettings .ForeColor = Color.White;
            btnSettings.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnSettings.Width / 2), (uiManager.frmAppMain.grpMain.Height * 16) / 30);
            btnSettings.TabIndex = 2;
            btnSettings.Click += BtnSettings_Click;
            uiManager.buttons.Add(btnSettings);
            uiManager.frmAppMain.grpMain.Controls.Add(btnSettings);

            btnCredits.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnCredits.Text = "Credits";
            btnCredits.TextAlign = ContentAlignment.MiddleCenter;
            btnCredits.Size = new Size(140, 80);
            btnCredits.ForeColor = Color.White;
            btnCredits.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnCredits.Width / 2), (uiManager.frmAppMain.grpMain.Height * 20) / 30);
            btnCredits.TabIndex = 3;
            btnCredits.Click += BtnCredits_Click;
            uiManager.buttons.Add(btnCredits);
            uiManager.frmAppMain.grpMain.Controls.Add(btnCredits);

            btnQuit.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnQuit.Text = "Quit";
            btnQuit.TextAlign = ContentAlignment.MiddleCenter;
            btnQuit.Size = new Size(140, 80);
            btnQuit.ForeColor = Color.White;
            btnQuit.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnQuit.Width / 2), (uiManager.frmAppMain.grpMain.Height * 24) / 30);
            btnQuit.TabIndex = 4;
            btnQuit.Click += BtnQuit_Click;
            uiManager.buttons.Add(btnQuit);
            uiManager.frmAppMain.grpMain.Controls.Add(btnQuit);

            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(388, 66);
            lblTitle.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblTitle.Width / 2, uiManager.frmAppMain.grpMain.Height * 4 / 30);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Main Menu";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);

            if (uiManager.frmAppMain.cardMode)
            {
                btnNewGame.GotFocus += GotFocus;
                btnSavedGame.GotFocus += GotFocus;
                btnSettings.GotFocus += GotFocus;
                btnCredits.GotFocus += GotFocus;
                btnQuit.GotFocus += GotFocus;
            }
        }
        /// <summary>
        /// Quit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            Application.Exit();
        }
        /// <summary>
        /// Go to Credits Ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCredits_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.ClearUi<MenuUi>();
            uiManager.frmAppMain.gameLayer = 3;
            uiManager.CreateUiComponents<CreditsIUi>();
        }
        /// <summary>
        /// Go to Settings Ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.ClearUi<MenuUi>();
            uiManager.frmAppMain.gameLayer = 5;
            uiManager.CreateUiComponents<SettingsUi>();
        }
        /// <summary>
        /// Go to Load game Ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSavedGame_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.ClearUi<MenuUi>();
            uiManager.frmAppMain.gameLayer = 4;
            uiManager.CreateUiComponents<SavedGameUi>();
        }
        /// <summary>
        /// Go to New game Ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);
            uiManager.ClearUi<MenuUi>();
            uiManager.CreateUiComponents<NewGameUi>();
        }
        /// <summary>
        /// Method to force focus on each buttons and change color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotFocus(object sender, EventArgs e)
        {
            if (sender == btnNewGame)
            {
                btnNewGame.TabIndex = 1;
                btnQuit.ForeColor = Color.White;
                btnNewGame.ForeColor = Color.ForestGreen;
                btnSavedGame.TabIndex = 0;

            }
            else if (sender == btnSavedGame)
            {
                btnSavedGame.TabIndex = 1;
                btnNewGame.ForeColor = Color.White;
                btnSavedGame.ForeColor = Color.ForestGreen;
                btnSettings.TabIndex = 0;
            }
            else if (sender == btnSettings)
            {
                btnSettings.TabIndex = 1;
                btnSavedGame.ForeColor = Color.White;
                btnSettings.ForeColor = Color.ForestGreen;
                btnCredits.TabIndex = 0;
            }
            else if (sender == btnCredits)
            {
                btnCredits.TabIndex = 1;
                btnSettings.ForeColor = Color.White;
                btnCredits.ForeColor = Color.ForestGreen;
                btnQuit.TabIndex = 0;
            }
            else if (sender == btnQuit)
            {
                btnQuit.TabIndex = 1;
                btnCredits.ForeColor = Color.White;
                btnQuit.ForeColor= Color.ForestGreen;
                btnNewGame.TabIndex = 0;
            }
        }
        /// <summary>
        /// Destroy all objects and clear the memory
        /// </summary>
        /// <param name="uiManager"></param>
        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            btnCredits.Dispose();
            btnSettings.Dispose();
            btnSavedGame.Dispose();
            btnNewGame.Dispose();
            btnQuit.Dispose();
            lblTitle.Dispose();
            uiManager.buttons.Clear();
        }
    }
}
