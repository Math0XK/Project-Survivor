using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class MenuUi : BaseUi
    {
        Button btnNewGame = new Button();
        Button btnSavedGame = new Button();
        Button btnSettings = new Button();
        Button btnCredits = new Button();
        Button btnQuit = new Button();
        Label lblTitle = new Label();

        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);
            btnNewGame.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnNewGame.Text = "New Game";
            btnNewGame.TextAlign = ContentAlignment.MiddleCenter;
            btnNewGame.Size = new Size(140, 80);
            btnNewGame.ForeColor = Color.White;
            btnNewGame.MouseClick += test;
            btnNewGame.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnNewGame.Width / 2), (uiManager.frmAppMain.grpMain.Height * 8) / 30);
            uiManager.frmAppMain.grpMain.Controls.Add(btnNewGame);

            btnSavedGame.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnSavedGame.Text = "Saved Game";
            btnSavedGame.TextAlign = ContentAlignment.MiddleCenter;
            btnSavedGame.Size = new Size(140, 80);
            btnSavedGame.ForeColor = Color.White;
            btnSavedGame.MouseClick += BtnSavedGame_MouseClick;
            btnSavedGame.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnSavedGame.Width / 2), (uiManager.frmAppMain.grpMain.Height * 12) / 30);
            uiManager.frmAppMain.grpMain.Controls.Add(btnSavedGame);

            btnSettings.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleCenter;
            btnSettings.Size = new Size(140, 80);
            btnSettings .ForeColor = Color.White;
            btnSettings.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnSettings.Width / 2), (uiManager.frmAppMain.grpMain.Height * 16) / 30);
            btnSettings.MouseClick += BtnSettings_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnSettings);

            btnCredits.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnCredits.Text = "Credits";
            btnCredits.TextAlign = ContentAlignment.MiddleCenter;
            btnCredits.Size = new Size(140, 80);
            btnCredits.ForeColor = Color.White;
            btnCredits.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnCredits.Width / 2), (uiManager.frmAppMain.grpMain.Height * 20) / 30);
            btnCredits.MouseClick += BtnCredits_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnCredits);

            btnQuit.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnQuit.Text = "Quit";
            btnQuit.TextAlign = ContentAlignment.MiddleCenter;
            btnQuit.Size = new Size(140, 80);
            btnQuit.ForeColor = Color.White;
            btnQuit.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (btnQuit.Width / 2), (uiManager.frmAppMain.grpMain.Height * 24) / 30);
            btnQuit.MouseClick += BtnQuit_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnQuit);

            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(388, 66);
            lblTitle.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblTitle.Width / 2, uiManager.frmAppMain.grpMain.Height * 4 / 30);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Main Menu";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);
        }

        private void BtnQuit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void BtnCredits_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.ClearUi<MenuUi>();
            uiManager.frmAppMain.gameLayer = 3;
            uiManager.CreateUiComponents<CreditsIUi>();
        }

        private void BtnSettings_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.frmAppMain.saveManager.ReadData();
        }

        private void BtnSavedGame_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.ClearUi<MenuUi>();
            uiManager.frmAppMain.gameLayer = 4;
            uiManager.CreateUiComponents<SavedGameUi>();
        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            btnCredits.Dispose();
            btnSettings.Dispose();
            btnSavedGame.Dispose();
            btnNewGame.Dispose();
            btnQuit.Dispose();
            lblTitle.Dispose();
            //uiManager.frmAppMain.gameLayer = 3;
            //uiManager.frmAppMain.soundManager.StopSound();
            //uiManager.frmAppMain.game = true;
        }

        private void test(object sender, MouseEventArgs e)
        {
            uiManager.ClearUi<MenuUi>();
            uiManager.CreateUiComponents<NewGameUi>();
        }
    }
}
