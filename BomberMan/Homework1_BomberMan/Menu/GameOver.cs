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
                DeadGameOver();
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
            this.BackButton();
        }

        private void VictoryGameOver()
        {
            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(25, 10);
            Console.WriteLine(@"
                          ██╗   ██╗██╗ ██████╗████████╗ ██████╗ ██████╗ ██╗   ██╗
                          ██║   ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
                          ██║   ██║██║██║        ██║   ██║   ██║██████╔╝ ╚████╔╝ 
                          ╚██╗ ██╔╝██║██║        ██║   ██║   ██║██╔══██╗  ╚██╔╝  
                           ╚████╔╝ ██║╚██████╗   ██║   ╚██████╔╝██║  ██║   ██║   
                            ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝                                                              
");
            Console.ResetColor();
            this.BackButton();
        }

        private void DeadGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"

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
");
            Console.ResetColor();
            this.BackButton();
        }

        public override void BackButton()
        {
            Console.SetCursorPosition(40, 21);
            base.BackButton();
            new MainMenu().MenuStart();
        }
    }
}

