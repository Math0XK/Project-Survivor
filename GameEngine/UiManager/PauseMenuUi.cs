using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class PauseMenuUi : BaseUi
    {
        Panel pnlPauseMain = new();
        Button btnBack = new();
        Button btnRestart = new();
        Button btnResume = new();
        Label lblTitle = new();
        Label lblDescription = new();
        internal override void OnCreate(UiManager uiManager)
        {
            base.OnCreate(uiManager);
            uiManager.frmAppMain.tmrGameUpdate.Stop();
            uiManager.frmAppMain.soundManager.pauseMusicLoop();

            pnlPauseMain.Size = new Size(uiManager.frmAppMain.grpMain.Width / 2, uiManager.frmAppMain.grpMain.Height / 2);
            pnlPauseMain.Location = new Point(uiManager.frmAppMain.grpMain.Width / 2 - pnlPauseMain.Width / 2, uiManager.frmAppMain.grpMain.Height /2 - pnlPauseMain.Height / 2);
            pnlPauseMain.BackColor = Color.Black;
            pnlPauseMain.ForeColor = Color.White;
            pnlPauseMain.BorderStyle = BorderStyle.FixedSingle;
            uiManager.frmAppMain.grpMain.Controls.Add(pnlPauseMain);
            uiManager.frmAppMain.grpMain.Controls.SetChildIndex(pnlPauseMain, 0);


            lblTitle.Font = new Font(UiManager.customFont.Families[0], 40, FontStyle.Regular);
            lblTitle.Size = new Size(388, 66);
            lblTitle.Location = new Point(pnlPauseMain.Width /2 - lblTitle.Width /2, 0);
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Pause";
            lblTitle.TabIndex = 0;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnlPauseMain.Controls.Add(lblTitle);



        }

        internal override void OnDestroy(UiManager uiManager)
        {
            base.OnDestroy(uiManager);
            uiManager.frmAppMain.tmrGameUpdate.Start();
            uiManager.frmAppMain.soundManager.resumeMusicLoop();

            pnlPauseMain.Dispose();
            lblTitle.Dispose();
        }
    }
}
