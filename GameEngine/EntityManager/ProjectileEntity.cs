using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ProjetVellemanTEST.GameEngine.EntityManager
{
    internal class ProjectileEntity : BaseEntity
    {
        //Create projectile
        internal override void onCreate(ProjetVellemanTEST.EntityManager entityManager)
        {
            base.onCreate(entityManager);
            mainPanel.Size = new Size(10, 20);
            mainPanel.Location = new Point(entityManager.frmAppMain.pnlPlayer.mainPanel.Left + entityManager.frmAppMain.pnlPlayer.mainPanel.Width / 2  - mainPanel.Width / 2, entityManager.frmAppMain.pnlPlayer.mainPanel.Top - entityManager.frmAppMain.pnlPlayer.mainPanel.Height + mainPanel.Height / 2 );
            mainPanel.Name = "Projectile";
            mainPanel.BackColor = Color.White;
            entityManager.frmAppMain.grpMain.Controls.Add(mainPanel);
            entityManager.frmAppMain.soundManager.PlaySoundEffect(entityManager.frmAppMain.soundManager.blastSoundEffect);
        }
        internal override void onDestroy(ProjetVellemanTEST.EntityManager entityManager)
        {
            entityManager.frmAppMain.currentProjectile--;
            base.onDestroy(entityManager);
            entityManager.frmAppMain.grpMain.Controls.Remove(mainPanel);
        }
    }
}
