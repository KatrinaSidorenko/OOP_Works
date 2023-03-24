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
        public GameObject[,] GameObjectsMap;
        private int _xSize = 16;
        private int _ySize = 16;
        Random RandomGanerator = new Random();

        public Map()
        {
            GameObjectsMap = new GameObject[_ySize, _xSize];
        }

        public void FillMap()
        {

            for (int y = 0; y < _ySize; y++)
            {
                for (int x = 0; x < _ySize; x++)
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
    }
}
