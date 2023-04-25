using Bomberman.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class Graphics
    {
        private GameLogic _gameLogic;
        private Map _currentMap;
        public Graphics(GameLogic gameLogic) 
        {
            _gameLogic = gameLogic;
            _currentMap = _gameLogic.MainMap;
        }
        public void DrawScene()
        {
            for (var i = 0; i < Constant.WindowYSize; i++)
            {
                for (var j = 0; j < Constant.WindowXSize; j++)
                {
                    _currentMap[i, j].Draw(i, j);
                }
                Console.WriteLine();
            }
            PrintCurrentPlayerData();
        }

        private void PrintCurrentPlayerData()
        {
            Console.SetCursorPosition(45, 9);
            Console.Write($"Player Score: {_gameLogic.Score}");
            Console.SetCursorPosition(45, 11);
            Console.WriteLine($"{_gameLogic.Walls} walls left to destroy");
            Console.SetCursorPosition(45, 13);
            Console.Write($"Time left: {_gameLogic.Timer.GetRestOfTheTime().ToString(@"mm\:ss")}");
        }
    }
}
