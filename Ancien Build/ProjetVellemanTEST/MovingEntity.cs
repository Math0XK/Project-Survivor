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

    internal class MovingEntity : BaseEntity
    {

        internal override void onCreate(EntityManager entityManager)
        {
            
            base.onCreate(entityManager);
            //base.onCreate(entityManager);
            mainPanel = new Panel();
            mainPanel.Location = new Point(0,0);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            mainPanel.Name = "Moving entity";
            mainPanel.Size = new System.Drawing.Size(50, 50);
            //panel.TabIndex = 1;
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
        }
        internal override void onDestroy(EntityManager entityManager)
        {
            base.onDestroy(entityManager);
            entityManager.frmAppMain.grpMain.Controls.Remove(mainPanel);
        }
    }

    internal class MovingEntityLeftDiagonal : BaseEntity
    {

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
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
        }

        internal override void onDestroy(EntityManager entityManager)
        {
            throw new NotImplementedException();
        }
    }
    internal class MovingEntityRightDiagonal : BaseEntity
    {

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
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
        }

        internal override void onDestroy(EntityManager entityManager)
        {
            throw new NotImplementedException();
        }
    }
    internal class MovingEntityPattern01 : BaseEntity
    {
        internal int cpt1 { get; set; } = 0;
        internal int cpt2 { get; set; } = 0;
        internal int setup { get; set; } = 0;

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
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
        }

        internal override void onDestroy(EntityManager entityManager)
        {
            throw new NotImplementedException();
        }
    }
}
