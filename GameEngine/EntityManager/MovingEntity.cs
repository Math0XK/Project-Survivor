﻿using System;
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
    //Create a linear moving entity
    internal class MovingEntitiy : BaseEntity
    {
        internal override void onCreate(EntityManager entityManager)
        {
            base.onCreate(entityManager);
            mainPanel.Location = new Point(0, 0);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(255, 201, 0);
            mainPanel.Name = "Moving entity";
            mainPanel.Size = new System.Drawing.Size(50, 50);
            points = 25;
            hostile = true;
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
        }
        internal override void onDestroy(EntityManager entityManager)
        {
            base.onDestroy(entityManager);
            mainPanel.Dispose();
            entityManager.frmAppMain.currentEntity--;
            entityManager.frmAppMain.grpMain.Controls.Remove(mainPanel);
        }
    }


}
