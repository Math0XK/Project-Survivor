using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST
{
    internal class InputManager
    {
        Dictionary<Keys, bool> KeyValuePairs = new Dictionary<Keys, bool>();
        public void onKeyDown(Keys pressedKey)
        {
            if(KeyValuePairs.ContainsKey(pressedKey))
            {
                KeyValuePairs[pressedKey] = true;
                return;
            }
            KeyValuePairs.Add(pressedKey, true);
        }
        public void onKeyUp(Keys pressedKey)
        {
            if (KeyValuePairs.ContainsKey(pressedKey))
            {
                KeyValuePairs[pressedKey] = false;
                return;
            }
            KeyValuePairs.Add(pressedKey, false);
        }

        public bool isKeyPressed(Keys pressedKey)
        {
            if(KeyValuePairs.ContainsKey(pressedKey)) return KeyValuePairs[pressedKey];
            return false;
        }
    }
}
