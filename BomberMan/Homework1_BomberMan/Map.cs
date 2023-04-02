using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class Map
    {
        private GameObject[,] GameObjectsMap;
        private Player _player = new Player(1, 2);
        private int _xSize = Constant.WindowXSize;
        private int _ySize = Constant.WindowYSize;
        private Random RandomGanerator = new Random();

        public Map()
        {
            GameObjectsMap = new GameObject[_ySize, _xSize];
            this.FillMap();
        }

        private void FillMap()
        {
            for (int y = 0; y < _ySize; y++)
            {
                for (int x = 0; x < _xSize; x++)
                {
                    if (x == 0 || y == 0 || x == _xSize - 1 || y == _ySize - 1)
                    {
                        GameObjectsMap[y, x] = new ConcreteWall();
                    }
                    else if (x % 2 == 0 && y % 2 == 0)
                    {
                        GameObjectsMap[y, x] = new ConcreteWall();
                    }
                    else if (RandomGanerator.Next(5) == 1)
                    {
                        GameObjectsMap[y, x] = new TempWall();
                    }
                    else
                    {
                        GameObjectsMap[y, x] = new EmptySpace();
                    }
                }
            }

        }

        public Player GetPlayer()
        {
            return _player;
        }

        public GameObject this[int y, int x]
        {
            get => GameObjectsMap[y, x];
            set 
            {
                GameObjectsMap[y, x] = value;
            } 
        }

        public void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            var symbol = ' ';
            for (var i = 0; i < _ySize; i++)
            {
                for (var j = 0; j < _xSize; j++)
                {
                    if (i == _player.Y && j == _player.X)
                    {
                        symbol = Constant.PlayerChar;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        symbol = this[i, j].Character;
                    }
                    Console.Write(symbol);
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}
