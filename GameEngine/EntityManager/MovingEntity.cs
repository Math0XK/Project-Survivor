using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjetVellemanTEST
{

    internal class MovingEntitiy : BaseEntity
    {
        internal Point starPos { get => mainPanel.Location; }
        internal Point endPos;
        internal override void onCreate(EntityManager entityManager)
        {

            base.onCreate(entityManager);
            //base.onCreate(entityManager);
            mainPanel = new Panel();
            mainPanel.Location = new Point(0, 0);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            mainPanel.Name = "Moving entity";
            mainPanel.Size = new System.Drawing.Size(50, 50);
            //panel.TabIndex = 1;
            hostile = true;
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
        }
        internal override void onDestroy(EntityManager entityManager)
        {
            base.onDestroy(entityManager);
            mainPanel?.Dispose();
            entityManager.frmAppMain.grpMain.Controls.Remove(mainPanel);
        }
    }


}
