
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class GameOver : Menu
    {
        public void CheckGameOver(GameState condition)
        {
            switch (condition)
            {
                case GameState.Victory:
                    PrintVictoryScene();
                    break;
                case GameState.TimeLeftEnd:
                    PrintTimeLeftScene();
                    break;
                case GameState.Dead:
                    PrintDiedScene();
                    break;
            }
        }
        private void PrintTimeLeftScene()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 5);
            Console.WriteLine($"Player {FileManager.GetPlayerName()} your time left".ToUpper());
            Console.SetCursorPosition(10, 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
                          ▄▄▄█████▓ ██▓ ███▄ ▄███▓▓█████     ██▓    ▓█████   █████▒▄▄▄█████▓
                          ▓  ██▒ ▓▒▓██▒▓██▒▀█▀ ██▒▓█   ▀    ▓██▒    ▓█   ▀ ▓██   ▒ ▓  ██▒ ▓▒
                          ▒ ▓██░ ▒░▒██▒▓██    ▓██░▒███      ▒██░    ▒███   ▒████ ░ ▒ ▓██░ ▒░
                          ░ ▓██▓ ░ ░██░▒██    ▒██ ▒▓█  ▄    ▒██░    ▒▓█  ▄ ░▓█▒  ░ ░ ▓██▓ ░ 
                            ▒██▒ ░ ░██░▒██▒   ░██▒░▒████▒   ░██████▒░▒████▒░▒█░      ▒██▒ ░ 
                             ▒ ░░   ░▓  ░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▓  ░░░ ▒░ ░ ▒ ░      ▒ ░░   
                             ░     ▒ ░░  ░      ░ ░ ░  ░   ░ ░ ▒  ░ ░ ░  ░ ░          ░    
                             ░       ▒ ░░      ░      ░        ░ ░      ░    ░ ░      ░      
                              ░         ░      ░  ░       ░  ░   ░  ░                                                                                               
");
            Console.ResetColor();
        }

        private void PrintVictoryScene()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 5);
            Console.WriteLine($"Player {FileManager.GetPlayerName()} you win".ToUpper());
            Console.SetCursorPosition(25, 10);
            string text = @"
                          ██╗   ██╗██╗ ██████╗████████╗ ██████╗ ██████╗ ██╗   ██╗
                          ██║   ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
                          ██║   ██║██║██║        ██║   ██║   ██║██████╔╝ ╚████╔╝ 
                          ╚██╗ ██╔╝██║██║        ██║   ██║   ██║██╔══██╗  ╚██╔╝  
                           ╚████╔╝ ██║╚██████╗   ██║   ╚██████╔╝██║  ██║   ██║   
                            ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝                                                              
";
            Animations.CreateRandomColorAnimation(text, 2);
            Console.ResetColor();
        }

        private void PrintDiedScene()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 5);
            Console.WriteLine($"Player {FileManager.GetPlayerName()} you died because you were hit by a bomb".ToUpper());
            Console.SetCursorPosition(0, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            
            string text = @"

                                ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄ 
                                ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌
                                 ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌
                                 ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌
                                 ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓ 
                                   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒ 
                                  ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒ 
                                  ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░ 
                                  ░ ░         ░ ░     ░           ░     ░     ░  ░   ░    
                                  ░ ░                           ░                  ░      
";
            Animations.CreateSimpleAnimation(text, 1);
            Console.ResetColor();
        }
    }
}

