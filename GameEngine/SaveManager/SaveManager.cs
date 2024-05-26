using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVellemanTEST.GameEngine.SaveManager
{
    internal class SaveManager
    {
        internal string path = "Resources\\SavesFile.txt";
        internal string txt;
        internal string[] Saves;
        internal string[] tabData = new string[7];
        private frmAppMain frmAppMain;

        public SaveManager(frmAppMain frmAppMain)
        {
            this.frmAppMain = frmAppMain;
        }

        internal void Save() { 
            StreamWriter streamWriter = new StreamWriter(path);
        }

        internal void test()
        {
            foreach (string s in Saves) { }
        }

        internal void getSaves()
        {
            StreamReader streamReader = new StreamReader(path);
            try
            {
                while (!streamReader.EndOfStream)
                {
                    txt = streamReader.ReadLine();
                    Saves = txt.Split('\n');
                }
            }
            catch (Exception e)
            {

            }
        }

    }
}
