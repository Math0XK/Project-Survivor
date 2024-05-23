using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST
{
	internal class InputManager
	{
		internal delegate void OnKeyDown(Keys key);
		public event OnKeyDown isAnyKeyDown;
		Dictionary<Keys, bool> KeyValuePairs = new Dictionary<Keys, bool>();
		public void onKeyDown(Keys pressedKey)
		{
			
			if(KeyValuePairs.ContainsKey(pressedKey))
			{
                KeyValuePairs[pressedKey] = true;
			}
			else
			{
                KeyValuePairs.Add(pressedKey, true);
            }
            isAnyKeyDown?.Invoke(pressedKey);
		}
		public void onKeyUp(Keys pressedKey)
		{
			if (KeyValuePairs.ContainsKey(pressedKey))
			{
				KeyValuePairs[pressedKey] = false;
				return;
			}
			KeyValuePairs.Clear();
		}

		public bool isKeyPressed(Keys pressedKey)
		{
			if (KeyValuePairs.ContainsKey(pressedKey))
			{
				return KeyValuePairs[pressedKey];
			}
			return false; 
		}
	}
}
