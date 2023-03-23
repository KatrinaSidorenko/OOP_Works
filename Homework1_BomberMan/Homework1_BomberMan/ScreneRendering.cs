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
    }
}
