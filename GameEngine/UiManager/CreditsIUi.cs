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

        /// <summary>
        /// Initiate all elements and display the Ui
        /// </summary>
        /// <param name="uiManager"></param>
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
            btnBack.TabIndex = 0;
            btnBack.Click += BtnBack_Click;
            uiManager.buttons.Add(btnBack);
            uiManager.frmAppMain.grpMain.Controls.Add(btnBack);

            btnDev = new Button();
            btnDev.Font = new Font(UiManager.customFont.Families[0], 11, FontStyle.Regular);
            btnDev.Size = new Size(140, 80);
            btnDev.ForeColor = Color.White;
            btnDev.Text = "Devlopement";
            btnDev.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnDev.Width / 2, uiManager.frmAppMain.grpMain.Height * 10 / 30);
            btnDev.TabIndex = 1;
            btnDev.Click += UpdateLabel;
            uiManager.buttons.Add(btnDev);
            uiManager.frmAppMain.grpMain.Controls.Add((btnDev));

            btnLicence = new Button();
            btnLicence.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            btnLicence.Size = new Size(140, 80);
            btnLicence.ForeColor = Color.White;
            btnLicence.Text = "Licence";
            btnLicence.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnLicence.Width / 2, uiManager.frmAppMain.grpMain.Height * 15 / 30);
            btnLicence.TabIndex = 1;
            btnLicence.Click += UpdateLabel;
            uiManager.buttons.Add(btnLicence);
            uiManager.frmAppMain.grpMain.Controls.Add((btnLicence));

            btnSoundtrack = new Button();
            btnSoundtrack.Font = new Font(UiManager.customFont.Families[0], 13, FontStyle.Regular);
            btnSoundtrack.Size = new Size(140, 80);
            btnSoundtrack.ForeColor = Color.White;
            btnSoundtrack.Text = "Soundtrack";
            btnSoundtrack.Location = new Point(uiManager.frmAppMain.grpMain.Width * 15 / 40 - btnSoundtrack.Width / 2, uiManager.frmAppMain.grpMain.Height * 20 / 30);
            btnSoundtrack.TabIndex = 1;
            btnSoundtrack.Click += UpdateLabel;
            uiManager.buttons.Add(btnSoundtrack);
            uiManager.frmAppMain.grpMain.Controls.Add((btnSoundtrack));

            lblCreditsDescription = new Label();
            lblCreditsDescription.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblCreditsDescription.Size = new Size(800, 420);
            lblCreditsDescription.ForeColor = Color.White;
            lblCreditsDescription.BackColor = Color.Transparent;
            lblCreditsDescription.Text = "\r\nDeveloped for the Department of Science and Technology at HEH Mons by Mathys Deboever. \r\n\r\nA big thank you to the beta testers:\r\n\r\n - Alpha Gaming\r\n - Buzz\r\n - Popou\r\n - Fab\r\n - Axel\r\n - Alesk\r\n - Moony";
            lblCreditsDescription.Location = new Point(uiManager.frmAppMain.grpMain.Width * 3 / 4 - lblCreditsDescription.Width / 2, uiManager.frmAppMain.grpMain.Height * 10 / 30);
            uiManager.frmAppMain.grpMain.Controls.Add(lblCreditsDescription);

            if (uiManager.frmAppMain.cardMode)
            {
                btnBack.GotFocus += GotFocus;
                btnDev.GotFocus += GotFocus;
                btnLicence.GotFocus += GotFocus;
                btnSoundtrack.GotFocus += GotFocus;
            }
        }
        /// <summary>
        /// Event that occurs when the back button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            uiManager.ClearUi<CreditsIUi>();
            uiManager.frmAppMain.gameLayer = 2;
            uiManager.CreateUiComponents<MenuUi>();
        }
        /// <summary>
        /// Destroy all objects and clear the memory
        /// </summary>
        /// <param name="uiManager"></param>
        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            lblCreditsDescription.Dispose();
            lblTitle.Dispose();
            btnSoundtrack.Dispose();
            btnLicence.Dispose();
            btnBack.Dispose();
            btnDev.Dispose();
            uiManager.buttons.Clear();

        }
        /// <summary>
        /// Update the text of the label when a button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateLabel(object sender, EventArgs e)
        {
            uiManager.frmAppMain.soundManager.PlaySoundEffect(uiManager.frmAppMain.soundManager.clickSoundEffect);

            if (sender == btnDev)
            {
                lblCreditsDescription.Text = "\r\nDeveloped for the Department of Science and Technology at HEH Mons by Mathys Deboever. \r\n\r\nA big thank you to the beta testers:\r\n\r\n - Alpha Gaming\r\n - Buzz\r\n - Popou\r\n - Fab\r\n - Axel\r\n - Alesk\r\n - Moony";
            }
            else if (sender == btnSoundtrack)
            {
                lblCreditsDescription.Text = "\r\nMusic: \r\n\r\n1. Shirobon - Hiraeth (Menu theme)\r\n2. Shirobon - Xilioh (Easy mode theme)\r\n3. Shirobon - The Chase (Medium mode theme)\r\n4. Shirobon - Vectors (Hard mode theme)\r\n5. Shirobon - Trident (Harder mode theme)\r\n6. Shirobon - Search Unit (Demon theme)\r\n\r\nSound effects:\r\n\r\nSound effects by Lucas NA, LIECIO and Pixabay from Pixabay.com";
            }
            else if (sender == btnLicence)
            {
                lblCreditsDescription.Text = "\r\nThis game was made for non-commercial purposes only.\r\n\r\nBorn Survivor © 2024 by Mathys Deboever is licensed under CC BY-NC-SA 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by-nc-sa/4.0/\r\n";
            }
        }
        /// <summary>
        /// Method to force focus on each buttons and change color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotFocus(object sender, EventArgs e)
        {
            if(sender == btnBack)
            {
                btnBack.TabIndex = 1;
                btnSoundtrack.ForeColor = Color.White;
                btnDev.ForeColor = Color.White;
                btnLicence.ForeColor = Color.White;
                btnBack.ForeColor = Color.ForestGreen;
                btnDev.TabIndex = 0;
            }
            if(sender == btnDev)
            {
                btnDev.TabIndex = 1;
                btnBack.ForeColor = Color.White;
                btnLicence.ForeColor= Color.White;
                btnSoundtrack.ForeColor= Color.White;
                btnDev.ForeColor= Color.ForestGreen;
                btnLicence.TabIndex = 0;
            }
            if(sender == btnLicence)
            {
                btnLicence.TabIndex = 1;
                btnDev.ForeColor = Color.White;
                btnSoundtrack.ForeColor = Color.White;
                btnBack.ForeColor= Color.White;
                btnLicence.ForeColor= Color.ForestGreen;
                btnSoundtrack.TabIndex = 0;
            }
            if(sender == btnSoundtrack)
            {
                btnSoundtrack.TabIndex = 1;
                btnLicence.ForeColor = Color.White;
                btnDev.ForeColor= Color.White;
                btnBack.ForeColor = Color.White;
                btnSoundtrack.ForeColor= Color.ForestGreen;
                btnBack.TabIndex = 0;
            }
        }
    }
}
