using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class StartupUi : BaseUi
    {
        Label lblTitle = new Label();
        Label lblDescription = new Label();
        internal int animationCounter = 100;

        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);
            lblDescription.Text = "Press any key to continue";
            lblTitle.Text = "Born Survivor";
            lblDescription.Font = new Font(UiManager.customFont.Families[0], 15, FontStyle.Regular);
            lblDescription.Size = new Size(336, 28);
            lblDescription.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (lblDescription.Width / 2), (uiManager.frmAppMain.grpMain.Height * 3) / 4);
            lblDescription.BackColor = Color.Transparent;
            lblDescription.ForeColor = Color.Transparent;
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            uiManager.frmAppMain.grpMain.Controls.Add(lblDescription);

            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Bold);
            lblTitle.Size = new Size(510, 64);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point((uiManager.frmAppMain.grpMain.Width / 2) - (lblTitle.Width / 2), (uiManager.frmAppMain.grpMain.Height * 1) / 4);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.Transparent;
            uiManager.frmAppMain.grpMain.Controls.Add(lblTitle);
        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            lblTitle.Dispose();
            lblDescription.Dispose();
        }

        internal override void OnResize(UiManager uiManager)
        {
            throw new NotImplementedException();
        }

        internal void Animation(UiManager uiManager)
        {
            if (animationCounter == 0)
            {
                lblDescription.Visible = !lblDescription.Visible;
                animationCounter = 50;
            }
            else animationCounter--;
        }
    }
}
