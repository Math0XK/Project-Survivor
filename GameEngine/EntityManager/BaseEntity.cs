using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST
{
    internal abstract class BaseEntity
    {
        internal bool destroyed = false;
        internal bool hostile = false;
        internal int points;
        internal Point location { get => mainPanel.Location; set => mainPanel.Location = value; }
        internal Size size { get => mainPanel.Size; set => mainPanel.Size = value; }

        internal Panel mainPanel = new();
        internal EntityManager EntityManager { get; set; }
        internal virtual void onCreate(EntityManager entityManager)
        {
            this.EntityManager = entityManager;
            mainPanel.TabIndex = 2;
        }

        internal virtual void onDestroy(EntityManager entityManager)
        {
            this.EntityManager = entityManager;
        }

    }
}
