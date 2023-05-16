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
        private List<GameMenuOption> _options;
        private int _index;

        public PlayerMenu()
        {
            _options = new List<GameMenuOption>
            {
                new GameMenuOption("♣", () => FileManager.WriteCharacterIntoFile("♣")),
                new GameMenuOption("I", () => FileManager.WriteCharacterIntoFile("I")),
                new GameMenuOption("▲", () => FileManager.WriteCharacterIntoFile("▲")),
                new GameMenuOption("▼", () => FileManager.WriteCharacterIntoFile("▼")),
                new GameMenuOption("$", () => FileManager.WriteCharacterIntoFile("$"))
            };
        }
        public void ProcessPlayerMenu()
        {
            Console.Clear();
            Console.Title = "BomberMan Menu";
            Console.CursorVisible = false;

            GetPlayerName();

            bool loop = true;
            while(loop)
            {
                DrawMenu(_options, _options[_index]);
                loop = base.HandleOptions(_options, _index);
            }
        }

        public override void DrawMenu(List<GameMenuOption> options, GameMenuOption selectedOption)
        {
            Console.SetCursorPosition(48, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose player character:".ToUpper());
            Console.ResetColor();
            Console.SetCursorPosition(40, 12);
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
