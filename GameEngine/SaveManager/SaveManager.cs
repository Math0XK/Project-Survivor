using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST.GameEngine.SaveManager
{
    internal class SaveManager
    {
        //Manage all methods related to save and load data

        private frmAppMain frmAppMain;

        public SaveManager(frmAppMain frmAppMain)
        {
            this.frmAppMain = frmAppMain;
        }

        private string FILE_NAME;

        internal int getFiles()
        {
            FILE_NAME = "Resources\\" + frmAppMain.pseudo + ".txt";
            if (File.Exists(FILE_NAME))
            {
                return 1;
            }
            else return 0;

        }
        internal void WriteData()
        {
            FILE_NAME = "Resources\\" + frmAppMain.pseudo + ".txt";
            // Create a string array with the lines of text
            string[] lines = { frmAppMain.highScore[0].ToString(), frmAppMain.highScore[1].ToString(), frmAppMain.highScore[2].ToString(), frmAppMain.highScore[3].ToString(), frmAppMain.highScore[4].ToString() };
            using (StreamWriter saves = new StreamWriter(FILE_NAME))
            {
                foreach(string line in lines) 
                    saves.WriteLine(line);
            }
        }

        internal void ReadData()
        {
            string[] tabData = new string[5];
            FILE_NAME = "Resources\\" + frmAppMain.pseudo + ".txt";
            try
            {
                // Open the text file using a stream reader.
                using StreamReader reader = new(FILE_NAME);

                // Read the stream as a string.
                string text = reader.ReadToEnd();

                //Convert data to int and stock information in highscore
                tabData = text.Split('\n');
                for(int i=0; i<5; i++)
                {
                    frmAppMain.highScore[i] = Int32.Parse(tabData[i]);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("The file could not be read:"+e.Message, "FILE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
