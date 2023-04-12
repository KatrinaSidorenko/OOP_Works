using BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BomberMan
{
    public class ScreneRender
    {
        private Map _gameMap;
        private KeyboardController _keyController;
        private Timer _timer;
        public ScreneRender(char playerChar)
        {
            _gameMap = new Map();
            //_gameMap.Player.SetGameCondition(_gameMap);
            _gameMap.Player.Character = playerChar;
            _keyController = new KeyboardController(_gameMap);
            _timer = new Timer();
        }

        public void GameProcessRun()
        {
            Console.CursorVisible = false;
            Console.Clear();

            while (true)
            {
                _gameMap.PrintMap();
                _keyController.KeyboardReading();
                PrintCurrentPlayerData();
                _timer.GemaOverTimeCheck();
            }                
        }

        public void PrintCurrentPlayerData()
        {
            Console.SetCursorPosition(45, 9);
            Console.Write($"Player Score: {GameProperties.Score}");
            Console.SetCursorPosition(45, 11);
            Console.WriteLine($"{TempWall.TotalAmountOfTempWalls} walls left to destroy");
            Console.SetCursorPosition(45, 13);
            Console.Write($"Time left: {_timer.GetRestOfTheTime().ToString(@"mm\:ss")}");        
        }
    }
}
