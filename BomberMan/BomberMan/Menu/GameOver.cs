
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class GameOver : Menu
    {
        public static void CheckGameOver(GameCondition condition)
        {
            if (condition == GameCondition.Victory)
            {
                VictoryGameOver();
            }
            if (condition == GameCondition.TimeLeftEnd)
            {
                GameOverTimeScene();
            }
            if (condition == GameCondition.Dead)
            {
                DiedGameOver();
            }
        }
        public static void GameOverTimeScene()
        {
            Console.Clear();
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
            Console.ReadKey(true);
        }

        public static void VictoryGameOver()
        {
            Console.Clear(); 
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
            Console.ReadKey(true);
        }

        public static void DiedGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 5);
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
            Console.ReadKey(true);
        }

        //public override void BackButton() Хочу спробувати додати перехід від кінцівки до початкового меню
        //{
        //    Console.SetCursorPosition(40, 21);
        //    base.BackButton();
        //    new MainMenu().MenuStart();
        //}
    }
}

