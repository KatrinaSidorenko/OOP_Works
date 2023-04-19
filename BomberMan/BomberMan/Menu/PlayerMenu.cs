using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class PlayerMenu : Menu
    {
        private static List<GameMenuOption> _options;
        private static int _index;

        public void PlayerCharacterMenuStart()
        {
            Console.Clear();
            Console.Title = "BomberMan Menu";
            Console.CursorVisible = false;

            _options = new List<GameMenuOption>
            {
                new GameMenuOption("♣", () => WriteIntoFile("♣")),
                new GameMenuOption("I", () => WriteIntoFile("I")),
                new GameMenuOption("▲", () => WriteIntoFile("▲")),
                new GameMenuOption("▼", () => WriteIntoFile("▼")),
                new GameMenuOption("$", () => WriteIntoFile("$")),
                new GameMenuOption("back".ToUpper(), () => new MainMenu().MenuStart())
            };

            DrawMenu(_options, _options[_index]);
            base.HandleOptions(_options, _index);
        }

        public override void DrawMenu(List<GameMenuOption> options, GameMenuOption selectedOption)
        {
            Console.SetCursorPosition(45, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose player character:".ToUpper());
            Console.ResetColor();
            Console.SetCursorPosition(30, 12);
            base.DrawMenu(options, selectedOption);
        }

        private void WriteIntoFile(string character)
        {
            var path = "C:\\Users\\Lenovo\\Desktop\\OOP_Works\\BomberMan\\BomberMan\\PlayerProperties.txt";
            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            File.WriteAllLines(path, lines);

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(character);
            sw.Close();
        }

    }
}
