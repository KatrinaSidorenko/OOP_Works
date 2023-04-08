using BomberMan.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
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
                new GameMenuOption("♣", () => new ScreneRender('♣').GameProcessRun()),
                new GameMenuOption("I", () => new ScreneRender('I').GameProcessRun()),
                new GameMenuOption("▲", () => new ScreneRender('▲').GameProcessRun()),
                new GameMenuOption("Ö", () => new ScreneRender('Ö').GameProcessRun()),
                new GameMenuOption("Return to main menu", () => new MainMenu().MenuStart())
            };

            DrawMenu(_options, _options[_index]);
            base.HandleOptions(_options, _index);
        }

        public override void DrawMenu(List<GameMenuOption> options, GameMenuOption selectedOption)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Choose player character:");

            base.DrawMenu(options, selectedOption);
        }

    }
}
