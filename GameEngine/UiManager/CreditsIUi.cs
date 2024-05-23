using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class CreditsIUi : BaseUi
    {
        Label lblCreditsDescription;
        Label lblTitle;
        Button btnBack;
        Button btnLicence;
        Button btnSoundtrack;
        Button btnDev;

        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);
            lblTitle = new();
            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(280, 66);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Credits";
            lblTitle.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - lblTitle.Width / 2, uiManager.frmAppMain.grpMain.Height * 4 / 30);
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);

            btnBack = new Button();
            btnBack.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnBack.Size = new Size(140, 80);
            btnBack.ForeColor = Color.White;
            btnBack.Text = "Back";
            btnBack.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - btnBack.Width / 2, uiManager.frmAppMain.grpMain.Height * 25 / 30);
            btnBack.MouseClick += BtnBack_MouseClick;
            uiManager.frmAppMain.grpMain.Controls.Add(btnBack);

            btnDev = new Button();
            btnDev.Font = new Font(UiManager.customFont.Families[0], 11, FontStyle.Regular);
            btnDev.Size = new Size(140, 80);
            btnDev.ForeColor = Color.White;
            btnDev.Text = "Devloppement";
            btnDev.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnDev.Width / 2, uiManager.frmAppMain.grpMain.Height * 10 / 30);
            btnDev.MouseClick += UpdateLabel;
            uiManager.frmAppMain.grpMain.Controls.Add((btnDev));

            btnLicence = new Button();
            btnLicence.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnLicence.Size = new Size(140, 80);
            btnLicence.ForeColor = Color.White;
            btnLicence.Text = "Licence";
            btnLicence.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnLicence.Width / 2, uiManager.frmAppMain.grpMain.Height * 15 / 30);
            btnLicence.MouseClick += UpdateLabel;
            uiManager.frmAppMain.grpMain.Controls.Add((btnLicence));

            btnSoundtrack = new Button();
            btnSoundtrack.Font = new Font(UiManager.customFont.Families[0], 13, FontStyle.Regular);
            btnSoundtrack.Size = new Size(140, 80);
            btnSoundtrack.ForeColor = Color.White;
            btnSoundtrack.Text = "Soundtrack";
            btnSoundtrack.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnSoundtrack.Width / 2, uiManager.frmAppMain.grpMain.Height * 20 / 30);
            btnSoundtrack.MouseClick += UpdateLabel;
            uiManager.frmAppMain.grpMain.Controls.Add((btnSoundtrack));

            lblCreditsDescription = new Label();
            lblCreditsDescription.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblCreditsDescription.Size = new Size(800, 420);
            lblCreditsDescription.ForeColor = Color.White;
            lblCreditsDescription.BackColor = Color.Transparent;
            lblCreditsDescription.Text = "DevloppementCredits_Description";
            lblCreditsDescription.Location = new Point(uiManager.frmAppMain.grpMain.Width * 3 / 4 - lblCreditsDescription.Width / 2, uiManager.frmAppMain.grpMain.Height * 10 / 30);
            uiManager.frmAppMain.grpMain.Controls.Add(lblCreditsDescription);
        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            lblCreditsDescription.Dispose();
            lblTitle.Dispose();
            btnSoundtrack.Dispose();
            btnLicence.Dispose();
            btnBack.Dispose();
            btnDev.Dispose();

        }

        private void UpdateLabel(object sender, MouseEventArgs e)
        {
            if(sender ==  btnDev) 
            {
                lblCreditsDescription.Text = "DevloppementCredits_Description";
            }
            else if(sender == btnSoundtrack) 
            {
                lblCreditsDescription.Text = "SoundtrackCredits_Description";
            }
            else if(sender == btnLicence)
            {
                lblCreditsDescription.Text = "LicenceDistubution_Description";
            }
        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            uiManager.ClearUi<CreditsIUi>();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.CreateUiComponents<MenuUi>();
        }
    }
}
