using BomberManGUI.Engine;
using System;
using BomberMan;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class MainGameLoop
    {
        private GameLogic _logic;
        private ConsoleSceneManager _graphics;
        private ConsoleInpuControler _inputController;

        public MainGameLoop()
        {
            _graphics = new ConsoleSceneManager();
            _logic = new GameLogic(_graphics);
            _inputController = new ConsoleInpuControler();
        }

        public void GameStart()
        {
            bool loop = true;
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowHeight = Console.BufferHeight = 30;

            Console.Clear();
            _graphics.DrawStartScene();

            while (loop)
            {                
                var inputAction = _inputController.GetInput();
                loop = _logic.ProcessGameLogic(inputAction);
            }

            Console.Clear();
            Environment.Exit(0);
        }
    }
}
