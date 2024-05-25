using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST
{
    internal class PlayerEntity : BaseEntity
    {
        internal bool isMoving = false;
        internal bool collisionX = false;
        internal bool collisionY = false;
        internal bool playerEnabled = false;

        internal override void onCreate(EntityManager entityManager)
        {
            if(!playerEnabled)
            {
                /*entityManager.frmAppMain.grpMain.SuspendLayout();
                entityManager.frmAppMain.SuspendLayout();*/
                base.onCreate(entityManager);
                //base.onCreate(entityManager);
                mainPanel = new Panel();
                mainPanel.Location = location;
                mainPanel.BackColor = System.Drawing.Color.White;
                mainPanel.Name = "Player";
                mainPanel.Size = size;
                //panel.TabIndex = 1;
                entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
                playerEnabled = true;
                hostile = false;
                /*entityManager.frmAppMain.grpMain.ResumeLayout(false);
                entityManager.frmAppMain.grpMain.PerformLayout();
                entityManager.frmAppMain.ResumeLayout(false);*/
            }

        }
        internal override void onDestroy(EntityManager entityManager)
        {
            playerEnabled = false;
            base.onDestroy(entityManager);
            entityManager.frmAppMain.grpMain.Controls.Remove(mainPanel);
            mainPanel.Dispose();
        }
    }
}
