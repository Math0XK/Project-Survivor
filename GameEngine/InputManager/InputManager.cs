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
		//Manage all events related to keyboard and get which
		//Key is pressed

		internal delegate void OnKeyDown(Keys key);
		public event OnKeyDown isAnyKeyDown;
		internal delegate void escapeDown(Keys key);
		public event escapeDown isEscapeDown;
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
			if(pressedKey == Keys.Escape)
			{
				isEscapeDown?.Invoke(pressedKey);
			}
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
