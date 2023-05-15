using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class MainMenu : Menu
    {
        private List<GameMenuOption> _options;
        private int _index;

        public MainMenu()
        {
            _options = new List<GameMenuOption>()
            {
                new GameMenuOption("Start Play", () =>
                {
                    Console.Clear();
                    new PlayerMenu().ProcessPlayerMenu();
                }),
                new GameMenuOption("Game Rules", () => ProcessHowToPlay()),
                new GameMenuOption("Exit", () => Environment.Exit(0))
            };
        }
        
        public void ShowMenuStart()
        {
            Console.Clear();
            Console.Title = "BomberMan";
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
        }

        public void ProcessMenuSatrt()
        {
            bool loop = true;

            while (loop)
            {
                ShowMenuStart();
                DrawMenu(_options, _options[_index]);
                loop = base.HandleOptions(_options, _index);
            } 
        }

        private void ShowHowToPlay()
        {
            Console.Clear();
            Console.WriteLine("The goal of the game:".ToUpper() + "destroy all the walls - 'o' in 2 minutes" +
                "\nBefore starting the game, you will be given the opportunity to choose the appearance of the player" +
                "\nSome explanations:" +
                "\n\t'@' - bomb mark" +
                "\n\t'#' - indestructible wall" +
                "\n\t'o' - temporary wall (this type of walls can has different strength)" +
                "\n\t'.' - explosion trace" +
                "\n\t'♦' - coin (here is differnt types of coin)" +
                "\nWARNING!! If you stay near the bomb for a long time, the explosion will kill you");
            Console.WriteLine();
        }

        public override void DrawMenu(List<GameMenuOption> options, GameMenuOption selectedOption)
        {
            Console.SetCursorPosition(45, 12);
            base.DrawMenu(options, selectedOption);
        }

        private void ProcessHowToPlay()
        {
            bool loop = true;
            while (loop)
            {
                ShowHowToPlay();
                loop = base.WaitForEnterButton();
            }

            ProcessMenuSatrt();
        }
    }
}