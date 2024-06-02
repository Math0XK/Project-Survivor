using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST
{
    //Create the player
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
                base.onCreate(entityManager);
                mainPanel.Location = location;
                mainPanel.BackColor = System.Drawing.Color.White;
                mainPanel.Name = "Player";
                mainPanel.Size = size;
                entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
                playerEnabled = true;
                hostile = false;
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
