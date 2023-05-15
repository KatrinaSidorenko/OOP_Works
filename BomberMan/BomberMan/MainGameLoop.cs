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
        private InputController _inputController;

        public MainGameLoop()
        {
            _menu = new MainMenu();
            _logic = new GameLogic();
            _graphics = new Graphics(_logic);
            _inputController = new InputController();
        }

        public void GameStart()
        {           
            var mainLoop = true;
            while (mainLoop)
            {
                bool loop = true;
                Console.Clear();
                Console.CursorVisible = false;
                Console.WindowHeight = Console.BufferHeight = 30;

                _menu.ProcessMenuSatrt();

                Console.Clear();

                while (loop)
                {
                    _graphics.DrawScene();
                    var inputAction = _inputController.GetInput();
                    loop = _logic.ProcessGameLogic(inputAction);
                }

                mainLoop = !(new Menu().WaitForEnterButton());
            }

            Console.Clear();
            Environment.Exit(0);
        }
    }
}
