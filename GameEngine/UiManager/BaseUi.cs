using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal abstract class BaseUi
    {
        internal UiManager uiManager;
        internal virtual void OnCreate(UiManager uiManager)
        {
            this.uiManager = uiManager;
        }
        internal virtual void OnDestroy(UiManager uiManager)
        {
            this.uiManager = uiManager;
        }
    }
}
