﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.EntityManager
{
    //Create a diagonal moving entity
    internal class MovingEntityDiagonal : BaseEntity
    {
        Random Random = new Random();
        internal int moveRL = 0;
        internal override void onCreate(ProjetVellemanTEST.EntityManager entityManager)
        {
            base.onCreate(entityManager);
            mainPanel.Location = new Point(0, 0);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(255, 143, 0);
            mainPanel.Name = "Moving entity";
            mainPanel.Size = new System.Drawing.Size(50, 50);
            hostile = true;
            points = 50;
            moveRL = Random.Next(0, 50);
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
