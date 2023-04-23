using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
                new GameMenuOption("♣", () => FileManager.WriteCharacterIntoFile("♣")),
                new GameMenuOption("I", () => FileManager.WriteCharacterIntoFile("I")),
                new GameMenuOption("▲", () => FileManager.WriteCharacterIntoFile("▲")),
                new GameMenuOption("▼", () => FileManager.WriteCharacterIntoFile("▼")),
                new GameMenuOption("$", () => FileManager.WriteCharacterIntoFile("$")),
                new GameMenuOption("back".ToUpper(), () => new MainMenu().MenuStart())
            };

            GetPlayerName();
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

        private void GetPlayerName()
        {
            Console.SetCursorPosition(47, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter your name:".ToUpper());
            Console.ResetColor();
            Console.SetCursorPosition(52, 12);
            string playerName = Console.ReadLine();
            FileManager.WritePlayerNameIntoFile(playerName);
            Console.Clear();
        }
    }
}
