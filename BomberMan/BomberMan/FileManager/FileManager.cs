using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bomberman
{
    public class FileManager
    {
        private static string _path = "C:\\Users\\Lenovo\\Desktop\\OOP_Works\\BomberMan\\BomberMan\\FileManager\\PlayerProperties.txt";
        public static void WriteCharacterIntoFile(string character)
        {
            File.AppendAllText(_path, "\n");
            File.AppendAllText(_path, character);
        }

        public static char GetCharacter()
        {
            var lines = File.ReadAllLines(_path).ToList();

            return char.Parse(lines[1]);
        }

        public static void WritePlayerNameIntoFile(string name)
        {
            ClearDocument();
            File.AppendAllText(_path, name);
        }

        private static void ClearDocument()
        {
            var lines = File.ReadAllLines(_path).ToList();
            lines.Clear();
            File.WriteAllLines(_path, lines);
        }

        public static string GatPlayerName()
        {
            var lines = File.ReadAllLines(_path).ToList();

            return lines[0];
        }
    }
}
