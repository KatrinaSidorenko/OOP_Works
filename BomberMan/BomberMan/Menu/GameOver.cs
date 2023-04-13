using BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class GameOver : Menu
    {
        public void CheckGameOver()
        {
            if (GameProperties.Condition == GameCondition.Victory)
            {
                VictoryGameOver();
            }
            if (GameProperties.Condition == GameCondition.TimeLeftEnd)
            {
                GameOverTimeScene();
            }
            if (GameProperties.Condition == GameCondition.Dead)
            {
                DiedGameOver();
            }
        }
        private void GameOverTimeScene()
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

        private void VictoryGameOver()
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

        private void DiedGameOver()
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

