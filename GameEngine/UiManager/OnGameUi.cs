using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class OnGameUi : BaseUi
    {
        Label lblHP = new();
        Label lblCharge = new();
        Label lblTicks = new();
        Panel pnlUi = new();

        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);

            pnlUi.Width = uiManager.frmAppMain.Width;
            pnlUi.Height = uiManager.frmAppMain.Height /40;
            pnlUi.BackColor = Color.Transparent;
            pnlUi.ForeColor = Color.White;
            pnlUi.BorderStyle = BorderStyle.FixedSingle;
            uiManager.frmAppMain.grpMain.Controls.Add(pnlUi);

            lblHP.Size = new Size(200, 50);
            lblHP.Location = new Point(0, 0);
            lblHP.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblHP.BackColor = Color.Transparent;
            lblHP.ForeColor = Color.White;
            lblHP.TextAlign = ContentAlignment.TopLeft;
            pnlUi.Controls.Add(lblHP);

            lblTicks.Size = new Size(300, 50);
            lblTicks.Location = new Point(pnlUi.Width/2 - lblTicks.Width/2, 0);
            lblTicks.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblTicks.BackColor = Color.Red;
            lblTicks.ForeColor = Color.White;
            lblTicks.TextAlign = ContentAlignment.TopCenter;
            pnlUi.Controls.Add (lblTicks);

            lblCharge.Size = new Size(200, 50);
            lblCharge.Location = new Point(pnlUi.Width - lblCharge.Width, 0);
            lblCharge.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblCharge.BackColor = Color.Transparent;
            lblCharge.ForeColor = Color.White;
            lblCharge .TextAlign = ContentAlignment.TopRight;
            pnlUi.Controls.Add(lblCharge);
        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
        }

        internal void updateOnGameUi()
        {
            lblTicks.Text = "Ticks : " + uiManager.frmAppMain.mainCpt;
            lblCharge.Text = "Charge : " + (uiManager.frmAppMain.charge - uiManager.frmAppMain.currentProjectile);
            lblHP.Text = "HP : "+ uiManager.frmAppMain.hp;
        }

    }
}
