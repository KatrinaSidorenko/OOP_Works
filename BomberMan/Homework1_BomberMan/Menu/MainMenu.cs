
using BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
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
            Console.WindowHeight = Console.BufferHeight = 30;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine(@"
                                      
                      ██████╗  ██████╗ ███╗   ███╗██████╗ ███████╗██████╗ ███╗   ███╗ █████╗ ███╗   ██╗
                      ██╔══██╗██╔═══██╗████╗ ████║██╔══██╗██╔════╝██╔══██╗████╗ ████║██╔══██╗████╗  ██║
                      ██████╔╝██║   ██║██╔████╔██║██████╔╝█████╗  ██████╔╝██╔████╔██║███████║██╔██╗ ██║
                      ██╔══██╗██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██╔══██╗██║╚██╔╝██║██╔══██║██║╚██╗██║
                      ██████╔╝╚██████╔╝██║ ╚═╝ ██║██████╔╝███████╗██║  ██║██║ ╚═╝ ██║██║  ██║██║ ╚████║
                      ╚═════╝  ╚═════╝ ╚═╝     ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝                                            
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
            Console.WriteLine("The goal of the game: destroy all the walls - 'o' in 2 minutes" +
                "\nBefore starting the game, you will be given the opportunity to choose the appearance of the player" +
                "\nSome explanations:" +
                "\n\t'@' - boma mark" +
                "\n\t'#' - indestructible wall" +
                "\n\t'o' - temporary wall" +
                "\n\t'.' - explosion trace" +
                "\n\t'♦' - coin" +
                "\nWARNING!! If you stay near the bomb for a long time, the explosion will kill you");
            Console.WriteLine();
            this.BackButton();
        }

        

        public override void DrawMenu(List<GameMenuOption> options, GameMenuOption selectedOption)
        {
            Console.SetCursorPosition(35, 12);
            base.DrawMenu(options, selectedOption);
        }

        public override void BackButton()
        {
            base.BackButton();
            this.MenuStart();
        }
    }
}