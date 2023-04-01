using BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class ScreneRender
    {
        private Map _gameMap;
        private KeyboardController _keyController;
        private Timer _timer;
        public ScreneRender()
        {
            _gameMap = new Map();
            _keyController = new KeyboardController(_gameMap);
            _timer = new Timer();
            Console.CursorVisible = false;
        }

        public void GameProcessRun()
        {
            while (true)
            {
                _gameMap.PrintMap();
                _keyController.KeyboardReading();
                _timer.GemaOverCheck(_gameMap.GetPlayer());
            }                
        }     
    }
}
