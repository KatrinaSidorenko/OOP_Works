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
        private  GameObject[,] gameObjectsMap;
        private int _xSize = 16;
        private int _ySize = 16;

        public Map()
        {
            gameObjectsMap = new GameObject[_ySize, _xSize];
        }

    }
}
