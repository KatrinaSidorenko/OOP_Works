using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Bomberman.GameObjects;

namespace Bomberman
{
    public class Map
    {
        private GameObject[,] _gameObjectsMap;
        public int TotalAmountOfTempWalls;
        public int PlayerXCoordiante;
        public int PlayerYCoordiante;
        private int _xSize = Constant.WindowXSize;
        private int _ySize = Constant.WindowYSize;
        private Random _rand = new Random();

        public Map()
        {
            _gameObjectsMap = new GameObject[_ySize, _xSize];            
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
                        _gameObjectsMap[y, x] = new ConcreteWall();
                    }
                    else if (_rand.Next(15) == 3 || _rand.Next(15) == 5)
                    {
                        _gameObjectsMap[y, x] = new ConcreteWall();
                    }
                    else if (_rand.Next(10) == 1)
                    {
                        if (_rand.Next(1, 8) == 1 || _rand.Next(2, 10) == 5) 
                        {
                            _gameObjectsMap[y, x] = new TempWall(ref TotalAmountOfTempWalls);
                        }
                        else
                        {
                            _gameObjectsMap[y, x] = new StrongTempWall(ref TotalAmountOfTempWalls);
                        }
                    }
                    else if (_rand.Next(20) == 15)
                    { 
                        if(_rand.Next(1,5) == 1)
                        {
                            _gameObjectsMap[y, x] = new ExpensiveCoin();
                        }
                        else
                        {
                            _gameObjectsMap[y, x] = new Coin();
                        }    
                    }
                    else
                    {
                        _gameObjectsMap[y, x] = new EmptySpace();
                    }
                }
            }

            PlayerXCoordiante = _rand.Next(1, Constant.WindowXSize - 1);
            PlayerYCoordiante = _rand.Next(1, Constant.WindowYSize - 1);

            _gameObjectsMap[PlayerYCoordiante, PlayerXCoordiante] = new Player();
        }

        public GameObject this[int y, int x]
        {
            get => _gameObjectsMap[y, x];
            set
            {
                _gameObjectsMap[y, x] = value;
            }
        }
    }
}
