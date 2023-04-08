using BomberMan.Menu;
using Homework1_BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class MainMenu : Menu
    {
        private static List<GameMenuOption> _options;
        private static int _index;
        
        public void MenuStart()
        {
            Console.Clear();
            Console.Title = "BomberMan Menu";
            Console.CursorVisible = false;

            Console.Write(@"
 _______                           __                            __       __                     
|       \                         |  \                          |  \     /  \                    
| $$$$$$$\  ______   ______ ____  | $$____    ______    ______  | $$\   /  $$  ______   _______  
| $$__/ $$ /      \ |      \    \ | $$    \  /      \  /      \ | $$$\ /  $$$ |      \ |       \ 
| $$    $$|  $$$$$$\| $$$$$$\$$$$\| $$$$$$$\|  $$$$$$\|  $$$$$$\| $$$$\  $$$$  \$$$$$$\| $$$$$$$\
| $$$$$$$\| $$  | $$| $$ | $$ | $$| $$  | $$| $$    $$| $$   \$$| $$\$$ $$ $$ /      $$| $$  | $$
| $$__/ $$| $$__/ $$| $$ | $$ | $$| $$__/ $$| $$$$$$$$| $$      | $$ \$$$| $$|  $$$$$$$| $$  | $$
| $$    $$ \$$    $$| $$ | $$ | $$| $$    $$ \$$     \| $$      | $$  \$ | $$ \$$    $$| $$  | $$
 \$$$$$$$   \$$$$$$  \$$  \$$  \$$ \$$$$$$$   \$$$$$$$ \$$       \$$      \$$  \$$$$$$$ \$$   \$$
                                                                                                 
                                                                                                 
                                                                                                 
"
            );

            _options = new List<GameMenuOption>
            {
                new GameMenuOption("Start Play", () =>
                {
                    Console.Clear();
                    new PlayerMenu().PlayerCharacterMenuStart();
                }),
                new GameMenuOption("Game Rules", () => HowToPlay()),
                new GameMenuOption("Exit", () => Environment.Exit(0))
            };

            DrawMenu(_options, _options[_index]);
            base.HandleOptions(_options, _index);
        }

        private void HowToPlay()
        {
            Console.Clear();
            Console.WriteLine("Here will be some instractions about game");
            BackButton();
        }

        private void BackButton()
        {
            Console.WriteLine("--> Return to the main menu");
            ConsoleKeyInfo ki = Console.ReadKey(true);

            while (ki.Key != ConsoleKey.Enter) ;

            Console.Clear();
            MenuStart();
        }

        public override void DrawMenu(List<GameMenuOption> options, GameMenuOption selectedOption)
        {
            Console.SetCursorPosition(0, 12);
            base.DrawMenu(options, selectedOption);
        }
    }
}