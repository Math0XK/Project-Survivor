﻿using System;
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
        internal Point endPos;

        internal Panel mainPanel;
        internal EntityManager EntityManager { get; set; }
        internal virtual void onCreate(EntityManager entityManager)
        {
            this.EntityManager = entityManager;
        }

        internal virtual void onDestroy(EntityManager entityManager)
        {
            this.EntityManager = entityManager;
        }

    }
}
