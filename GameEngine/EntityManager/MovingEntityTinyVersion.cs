using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.EntityManager
{
    internal class MovingEntityTinyVersion : BaseEntity
    {
        internal override void onCreate(ProjetVellemanTEST.EntityManager entityManager)
        {
            base.onCreate(entityManager);
            mainPanel.Location = new Point(0, 0);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(255, 48, 0);
            mainPanel.Name = "Moving entity";
            mainPanel.Size = new System.Drawing.Size(25, 25);
            hostile = true;
            points = 200;
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
