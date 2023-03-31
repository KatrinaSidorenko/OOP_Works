using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class ScreneRendering
    {
        private GameObject[,] _gameMap;
        private Player _player = new Player(1, 2);
        public ScreneRendering()
        {
            var map = new Map();
            map.FillMap();
            _gameMap = map.GameObjectsMap;
            Console.CursorVisible = false;
        }

        public void GameProcess()
        {
            bool temp;
            do
            {
                Console.Clear();
                PrintMap();
                _player.DrawPlayer();
                temp = KeyboardReading(); 
            }while(temp);
        }

        public void PrintMap()
        {
            for (int y = 0; y < _gameMap.GetLength(0); y++)
            {
                for (int x = 0; x < _gameMap.GetLength(1); x++)
                {
                    Console.Write(_gameMap[y, x].Character);
                }
                Console.WriteLine();
            }
        }

        public bool KeyboardReading()
        {
            ConsoleKeyInfo ki = Console.ReadKey(true);
            if (ki.Key == ConsoleKey.Escape)
            {
                return false;
            }
            if (ki.Key == ConsoleKey.LeftArrow && _gameMap[_player.Y, _player.X - 1].Character == Constant.EmptySpaceChar)
            {
                _player.X--;
            }
            if (ki.Key == ConsoleKey.RightArrow && _gameMap[_player.Y, _player.X + 1].Character == Constant.EmptySpaceChar)
            {
                _player.X++;
            }
            if (ki.Key == ConsoleKey.UpArrow && _gameMap[_player.Y - 1, _player.X].Character == Constant.EmptySpaceChar)
            {
                _player.Y--;
            }
            if (ki.Key == ConsoleKey.DownArrow && _gameMap[_player.Y + 1, _player.X].Character == Constant.EmptySpaceChar)
            {
                _player.Y++;
            }

            return true;
        }
    }
}
