using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class MainGameLoop
    {
        private MainMenu _menu;
        private GameLogic _logic;
        private Graphics _graphics;

        public MainGameLoop()
        {
            _menu = new MainMenu();  
        }

        public void GameStart()
        {
            _menu.MenuStart();
            _logic = new GameLogic();
            _graphics = new Graphics(_logic);

            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowHeight = Console.BufferHeight = 30;

            while(true)
            {
                _graphics.DrawMap();
                _logic.ProcessGameLogic();
            }  
        }
    }
}
