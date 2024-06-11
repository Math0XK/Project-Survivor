using ProjetVellemanTEST.GameEngine.K8055DManager;
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
        Label lblScore = new();
        Label lblDiff = new();
        Panel pnlUi = new();

        /// <summary>
        /// Initiate all elements and display the Ui
        /// </summary>
        /// <param name="uiManager"></param>
        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);

            pnlUi.Width = uiManager.frmAppMain.Width - 2;
            pnlUi.Height = uiManager.frmAppMain.Height /40;
            pnlUi.BackColor = Color.Transparent;
            pnlUi.ForeColor = Color.White;
            pnlUi.BorderStyle = BorderStyle.FixedSingle;
            uiManager.frmAppMain.grpMain.Controls.Add(pnlUi);

            lblHP.Size = new Size(200, uiManager.frmAppMain.Height / 40);
            lblHP.Location = new Point(0, 0);
            lblHP.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblHP.BackColor = Color.Transparent;
            lblHP.ForeColor = Color.White;
            lblHP.TextAlign = ContentAlignment.MiddleLeft;
            pnlUi.Controls.Add(lblHP);

            lblTicks.Size = new Size(300, uiManager.frmAppMain.Height / 40);
            lblTicks.Location = new Point(uiManager.frmAppMain.grpMain.Width/2 - lblTicks.Width/2, 0);
            lblTicks.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblTicks.BackColor = Color.Transparent;
            lblTicks.ForeColor = Color.White;
            lblTicks.TextAlign = ContentAlignment.MiddleCenter;
            pnlUi.Controls.Add(lblTicks);

            lblCharge.Size = new Size(200, uiManager.frmAppMain.Height / 40);
            lblCharge.Location = new Point(lblHP.Width , 0);
            lblCharge.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblCharge.BackColor = Color.Transparent;
            lblCharge.ForeColor = Color.White;
            lblCharge .TextAlign = ContentAlignment.TopCenter;
            pnlUi.Controls.Add(lblCharge);

            lblScore.Size = new Size(300, uiManager.frmAppMain.Height / 40);
            lblScore.Location = new Point(uiManager.frmAppMain.Width - lblScore.Width , 0);
            lblScore.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
            lblScore.BackColor = Color.Transparent;
            lblScore.ForeColor = Color.White;
            lblScore.TextAlign = ContentAlignment.TopRight;
            pnlUi.Controls.Add (lblScore);

            if (uiManager.frmAppMain.cardMode)
            {
                Fctvm110.SetAllDigital();
                lblDiff.Size = new Size(300, uiManager.frmAppMain.Height / 40);
                lblDiff.Location = new Point(uiManager.frmAppMain.Width - lblScore.Width - lblDiff.Width, 0);
                lblDiff.Font = new Font(UiManager.customFont.Families[0], 16, FontStyle.Regular);
                lblDiff.BackColor = Color.Transparent;
                lblDiff.ForeColor = Color.White;
                lblDiff .TextAlign = ContentAlignment.TopLeft;
                pnlUi.Controls.Add(lblDiff);
            }
        }
        /// <summary>
        /// Destroy all objects and clear the memory
        /// </summary>
        /// <param name="uiManager"></param>
        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            lblScore.Dispose();
            lblCharge.Dispose();
            lblHP.Dispose();
            lblTicks.Dispose();
            pnlUi.Dispose();
        }
        /// <summary>
        /// Update informations displayed
        /// </summary>
        internal void updateOnGameUi()
        {
            lblTicks.Text = "Time : " + uiManager.frmAppMain.mainCpt;
            lblCharge.Text = "Charge : " + (uiManager.frmAppMain.charge - uiManager.frmAppMain.currentProjectile);
            lblHP.Text = "HP : "+ uiManager.frmAppMain.hp;
            lblScore.Text = "Score : "+ uiManager.frmAppMain.score;
            if (uiManager.frmAppMain.cardMode)
            {
                lblDiff.Text = "Difficulty = " + uiManager.frmAppMain.entityManager.K8055Diff;
            }
        }

    }
}
