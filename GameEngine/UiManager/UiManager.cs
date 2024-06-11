using ProjetVellemanTEST.GameEngine.SoundManager;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.UiManager
{
    internal class UiManager 
    {
        //Manage ui creation and ui destruction
        //Add custom font
        //Manage usefull parameters

        internal int mode = 0;
        internal bool win = false;

        internal static PrivateFontCollection customFont = new PrivateFontCollection();
        public frmAppMain frmAppMain {  get; private set; }
        public UiManager(frmAppMain frmAppMain)
        {
            this.frmAppMain = frmAppMain;
            customFont.AddFontFile("Resources\\PixeloidMono-d94EV.ttf");
        }

        List<BaseUi> uiComponents = new List<BaseUi>();
        internal List<Button> buttons = new List<Button>();

        /// <summary>
        /// Method used to create every types of ui
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal T CreateUiComponents<T>() where T : BaseUi, new()
        {
            T ui = new T();
            uiComponents.Add(ui);
            ui.OnCreate(this);
            return ui;
        }
        /// <summary>
        /// Method used to clear every types of ui
        /// </summary>
        /// <typeparam name="T"></typeparam>
        internal void ClearUi<T>() where T : BaseUi
        {
            List<BaseUi>copy = new List<BaseUi>(uiComponents);
            foreach (BaseUi ui in copy)
            {
                if(ui is T ui1)
                {
                    uiComponents.Remove(ui1);
                    ui1.OnDestroy(this);
                }
            }
        }
        /// <summary>
        /// Method used to animate the startup Ui
        /// </summary>
        internal void StartupAnimation()
        {
            foreach(BaseUi ui in uiComponents)
            {
                if(ui is StartupUi ui1)
                {
                    ui1.Animation(this);
                }
            }
        }
        /// <summary>
        /// Method used to update on game ui
        /// </summary>
        internal void UpdateUi()
        {
            foreach(BaseUi ui in uiComponents)
            {
                if (ui is OnGameUi ui1)
                {
                    ui1.updateOnGameUi();
                }
            }
        }
    }
}
