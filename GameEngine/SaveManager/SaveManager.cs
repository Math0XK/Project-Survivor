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
        internal string path = "Resources\\SavesFile.txt";
        private frmAppMain frmAppMain;

        public SaveManager(frmAppMain frmAppMain)
        {
            this.frmAppMain = frmAppMain;
        }

        internal void GetFiles()
        {
            try
            {
                // Set a variable to the My Documents path.
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

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

        private const string FILE_NAME = "Test.txt";

        internal void CreateFiles()
        {
            if (File.Exists(FILE_NAME))
            {
                Console.WriteLine($"{FILE_NAME} already exists!");
                return;
            }

            using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))
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
            }
        }

    }
}
