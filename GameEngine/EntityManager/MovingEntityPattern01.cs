using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.EntityManager
{
    internal class MovingEntityPattern01 : BaseEntity
    {
        internal override void onCreate(ProjetVellemanTEST.EntityManager entityManager)
        {
            base.onCreate(entityManager);
            mainPanel = new Panel();
            mainPanel.Location = new Point(0, 0);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            mainPanel.Name = "Moving entity";
            mainPanel.Size = new System.Drawing.Size(50, 50);
            hostile = true;
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
        }

        internal override void onDestroy(ProjetVellemanTEST.EntityManager entityManager)
        {
            base.onDestroy(entityManager);
            mainPanel.Dispose();
            entityManager.frmAppMain.currentEntity--;
            entityManager.frmAppMain.grpMain.Controls.Remove(mainPanel);
        }
    }
}
