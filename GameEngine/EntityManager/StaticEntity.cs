using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST
{
    internal class StaticEntity : BaseEntity
    {
        internal override void onCreate(EntityManager entityManager)
        {
            entityManager.frmAppMain.grpMain.SuspendLayout();
            entityManager.frmAppMain.SuspendLayout();
            base.onCreate(entityManager);
            //base.onCreate(entityManager);
            mainPanel.Location = new Point(location.X, location.Y);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            mainPanel.Name = "Moving entity";
            mainPanel.Size = new System.Drawing.Size(50, 50);
            //panel.TabIndex = 1;
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
            /*entityManager.frmAppMain.grpMain.ResumeLayout(false);
            entityManager.frmAppMain.grpMain.PerformLayout();
            entityManager.frmAppMain.ResumeLayout(false);*/
        }
        internal override void onDestroy(EntityManager entityManager)
        {
            base.onDestroy(entityManager);
            entityManager.frmAppMain.currentEntity--;
            entityManager.frmAppMain.grpMain.Controls.Remove(mainPanel);
            mainPanel.Dispose();
        }
    }
}
