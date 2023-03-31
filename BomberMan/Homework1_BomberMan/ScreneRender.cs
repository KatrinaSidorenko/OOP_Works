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
        public ScreneRender()
        {
            _gameMap = new Map();
            _keyController = new KeyboardController(_gameMap);
            Console.CursorVisible = false;
        }

        public void GameProcessRun()
        {
            bool temp;
            do
            {
                _gameMap.PrintMap();
                temp = _keyController.KeyboardReading(); 
            }while(temp);
        }     
    }
}
