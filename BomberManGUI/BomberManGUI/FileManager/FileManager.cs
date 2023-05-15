using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberManGUI.FileManager
{
    public class FileManager
    {
        private static string _path = _path ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"GameProperties.txt");
        public static void WritePlayerNameIntoFile(string name)
        {
            using (StreamWriter sr = File.CreateText(_path))
            {
                sr.Write(name);
            }
        }

        private static void ClearDocument()
        {
            var lines = File.ReadAllLines(_path).ToList();
            lines.Clear();
            File.WriteAllLines(_path, lines);
        }

        public static string GetPlayerName()
        {
            return File.ReadAllText(_path);
        }
    }
}
