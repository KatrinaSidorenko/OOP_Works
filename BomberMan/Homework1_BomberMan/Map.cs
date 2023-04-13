using BomberMan;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class Map
    {
        private GameObject[,] GameObjectsMap;
        public Player Player { get; } = new Player();
        private int _xSize = Constant.WindowXSize;
        private int _ySize = Constant.WindowYSize;
        private Random RandomGanerator = new Random();

        public Map()
        {
            GameObjectsMap = new GameObject[_ySize, _xSize];
            this.FillMap();
            Player.Start(ref GameObjectsMap);
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
                    else if (RandomGanerator.Next(15) == 3 || RandomGanerator.Next(15) == 5)
                    {
                        GameObjectsMap[y, x] = new ConcreteWall();
                    }
                    else if (RandomGanerator.Next(10) == 1)
                    {
                        GameObjectsMap[y, x] = new TempWall();
                    }
                    else if(RandomGanerator.Next(20) == 15)
                    {
                        GameObjectsMap[y, x] = new Coin();
                    }
                    else
                    {
                        GameObjectsMap[y, x] = new EmptySpace();
                    }
                }
            }

            GameObjectsMap[Player.Y, Player.X] = new EmptySpace();
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
            for (var i = 0; i < _ySize; i++)
            {
                for (var j = 0; j < _xSize; j++)
                {
                    if (i == Player.Y && j == Player.X)
                    {
                        Player.Draw(i, j);
                    }
                    else
                    {
                        this[i, j].Draw(i, j);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
