using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVellemanTEST.GameEngine.SaveManager
{
    internal class SaveManager
    {
        private frmAppMain frmAppMain;

        public SaveManager(frmAppMain frmAppMain)
        {
            this.frmAppMain = frmAppMain;
        }

        internal void CountFiles()
        {
            FILE_NAME = "Resources\\" + frmAppMain.pseudo + ".txt";
            try
            {
                // Set a variable to the My Documents path.
                string docPath = FILE_NAME;

                List<string> dirs = new List<string>(Directory.EnumerateDirectories(docPath));

                foreach (var dir in dirs)
                {
                    Console.WriteLine($"{dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1)}");
                }
                Console.WriteLine($"{dirs.Count} directories found.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string FILE_NAME;

        internal int getFiles()
        {
            FILE_NAME = "Resources\\" + frmAppMain.pseudo + ".txt";
            if (File.Exists(FILE_NAME))
            {
                Console.WriteLine($"{FILE_NAME} already exists!");
                return 1;
            }
            else return 0;

            /*using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))
            {
                using (StreamWriter w = new StreamWriter(fs))
                {
                    for (int i = 0; i < 11; i++)
                    {
                        w.Write(i);
                    }
                }
            }

            using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader r = new StreamReader(fs))
                {
                    while (!r.EndOfStream)
                    {
                        Console.WriteLine(r.ReadLine());
                    }
                }
            }*/

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

            /*// Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }*/
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

                tabData = text.Split('\n');
                for(int i=0; i<5; i++)
                {
                    frmAppMain.highScore[i] = Int32.Parse(tabData[i]);
                }
                // Write the text to the console.
                Console.WriteLine(text);
                Console.WriteLine(frmAppMain.highScore[0]+"\n");
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

    }
}
