using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            lblTitle.Size = new Size(388, 66);
            lblTitle.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblTitle.Width / 2, uiManager.frmAppMain.grpMain.Height * 4 / 30);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Choose the dificulty";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);

            btnBack.Size = new Size(140, 80);
            btnBack.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnBack.Text = "Back";
            btnBack.ForeColor = Color.White;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2 - btnBack.Width / 2) * 16 / 20, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            btnBack.MouseClick += BtnBack_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnBack);

            btnNext.Size = new Size(140, 80);
            btnNext.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnNext.Text = "Confirm";
            btnNext.ForeColor = Color.White;
            btnNext.TextAlign = ContentAlignment.MiddleCenter;
            btnNext.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2 - btnNext.Width / 2) * 24 / 20, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            btnNext.MouseClick += BtnNext_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnNext);

            btnEasyMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnEasyMode.Size = new Size(140, 80);
            btnEasyMode.ForeColor = Color.White;
            btnEasyMode.Text = "Easy";
            btnEasyMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnEasyMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 7 / 30);
            btnEasyMode.MouseClick += UpdateLabel;
            uiManager.frmAppMain.grpMain.Controls.Add((btnEasyMode));

            btnMediumMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnMediumMode.Size = new Size(140, 80);
            btnMediumMode.ForeColor = Color.White;
            btnMediumMode.Text = "Medium";
            btnMediumMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnMediumMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 10 / 30);
            btnMediumMode.MouseClick += UpdateLabel;
            uiManager.frmAppMain.grpMain.Controls.Add((btnMediumMode));

            btnHardMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnHardMode.Size = new Size(140, 80);
            btnHardMode.ForeColor = Color.White;
            btnHardMode.Text = "Hard";
            btnHardMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnHardMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 13 / 30);
            btnHardMode.MouseClick += UpdateLabel;
            uiManager.frmAppMain.grpMain.Controls.Add((btnHardMode));

            btnHarderMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnHarderMode.Size = new Size(140, 80);
            btnHarderMode.ForeColor = Color.White;
            btnHarderMode.Text = "Harder";
            btnHarderMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnHarderMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 16 / 30);
            btnHarderMode.MouseClick += UpdateLabel;
            uiManager.frmAppMain.grpMain.Controls.Add((btnHarderMode));

            btnDemonMode.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnDemonMode.Size = new Size(140, 80);
            btnDemonMode.ForeColor = Color.White;
            btnDemonMode.Text = "Demon";
            btnDemonMode.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnDemonMode.Width / 2, uiManager.frmAppMain.grpMain.Height * 19 / 30);
            btnDemonMode.MouseClick += UpdateLabel;
            uiManager.frmAppMain.grpMain.Controls.Add((btnDemonMode));

            lblModeDescription.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblModeDescription.Size = new Size(800, 420);
            lblModeDescription.ForeColor = Color.White;
            lblModeDescription.BackColor = Color.Transparent;
            lblModeDescription.Text = "DevloppementCredits_Description";
            lblModeDescription.Location = new Point(uiManager.frmAppMain.grpMain.Width * 3 / 4 - lblModeDescription.Width / 2, uiManager.frmAppMain.grpMain.Height * 10 / 30);
            uiManager.frmAppMain.grpMain.Controls.Add(lblModeDescription);
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
        }

        private void UpdateLabel(object sender, MouseEventArgs e)
        {
            
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
