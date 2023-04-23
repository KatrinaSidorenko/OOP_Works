
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
        public void CheckGameOver(GameCondition condition)
        {
            switch (condition)
            {
                case GameCondition.Victory:
                    VictoryGameOver();
                    break;
                case GameCondition.TimeLeftEnd:
                    GameOverTimeScene();
                    break;
                case GameCondition.Dead:
                    DiedGameOver();
                    break;
            }
        }
        public void GameOverTimeScene()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 5);
            Console.WriteLine($"Player {FileManager.GatPlayerName()} your time left".ToUpper());
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
            BackButton();
        }

        public  void VictoryGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 5);
            Console.WriteLine($"Player {FileManager.GatPlayerName()} you win".ToUpper());
            Console.SetCursorPosition(25, 10);
            string text = @"
                          ██╗   ██╗██╗ ██████╗████████╗ ██████╗ ██████╗ ██╗   ██╗
                          ██║   ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
                          ██║   ██║██║██║        ██║   ██║   ██║██████╔╝ ╚████╔╝ 
                          ╚██╗ ██╔╝██║██║        ██║   ██║   ██║██╔══██╗  ╚██╔╝  
                           ╚████╔╝ ██║╚██████╗   ██║   ╚██████╔╝██║  ██║   ██║   
                            ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝                                                              
";
            Animations.RandomColorAnimation(text, 2);
            Console.ResetColor();
            BackButton();
        }

        public void DiedGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 5);
            Console.WriteLine($"Player {FileManager.GatPlayerName()} you died because you were hit by a bomb".ToUpper());
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
            Animations.SimpleAnimation(text, 1);
            Console.ResetColor();
            BackButton();
        }

        public override void BackButton() 
        {
            Console.SetCursorPosition(40, 21);
            base.BackButton();
            new MainGameLoop().GameStart();
        }
    }
}

