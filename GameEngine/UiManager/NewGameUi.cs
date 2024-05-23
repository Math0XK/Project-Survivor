using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class NewGameUi : BaseUi
    {
        internal TextBox playerName;
        internal string pseudo;
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
            playerName.Location = new Point(uiManager.frmAppMain.grpMain.Width/2 - playerName.Width/2, uiManager.frmAppMain.grpMain.Height * 16/30);
            uiManager.frmAppMain.grpMain.Controls.Add(playerName);

            lblNameDescription = new Label();
            lblNameDescription.Font = new Font(UiManager.customFont.Families[0], 18, FontStyle.Regular);
            lblNameDescription.Size = new Size(495, 32);
            lblNameDescription.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblNameDescription.Width / 2, uiManager.frmAppMain.grpMain.Height * 12 / 30);
            lblNameDescription.BackColor = Color.Transparent;
            lblNameDescription.ForeColor = Color.White;
            lblNameDescription.Text = "What is your survivor's name ?";
            lblNameDescription.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblNameDescription);

            lblTitle = new Label();
            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(388, 66);
            lblTitle.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblTitle.Width / 2, uiManager.frmAppMain.grpMain.Height * 4 / 30);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "New Player";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);

            btnBack = new Button();
            btnBack.Size = new Size(140, 80);
            btnBack.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnBack.Text = "Back";
            btnBack.ForeColor = Color.White;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2 - btnBack.Width / 2) * 16 / 20, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            btnBack.MouseClick += BtnBack_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnBack);

            btnNext = new Button();
            btnNext.Size = new Size(140, 80);
            btnNext.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnNext.Text = "Confirm";
            btnNext.ForeColor = Color.White;
            btnNext.TextAlign = ContentAlignment.MiddleCenter;
            btnNext.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2 - btnNext.Width / 2) * 24 / 20, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            btnNext.MouseClick += BtnNext_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnNext);
        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            lblNameDescription.Dispose();
            lblTitle.Dispose();
            btnBack.Dispose();
            btnNext.Dispose();
            playerName.Dispose();
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            if(playerName.Text == "")
            {
                MessageBox.Show("Every survivor has a name\n\r Please, enter yours", "No name", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                pseudo = playerName.Text;
                uiManager.ClearUi<NewGameUi>();
                uiManager.frmAppMain.gameLayer = 999;
            }
        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.ClearUi <NewGameUi>();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.CreateUiComponents<MenuUi>();
        }
    }
}
