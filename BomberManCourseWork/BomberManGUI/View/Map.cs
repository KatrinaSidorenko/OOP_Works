using System;
using BomberManGUI.GameObjects;
using BomberManGUI.Enums;
using BomberManGUI.GameObjects.Walls;

namespace BomberManGUI.View
{
    public class Map
    {
        public int TotalAmountOfTempWalls;
        public int PlayerXCoordiante;
        public int PlayerYCoordiante;
        private GameObject[,] _gameObjectsMap;       
        private int _xSize = Constant.WindowXSize;
        private int _ySize = Constant.WindowYSize;
        private Random _rand = new Random();

        public Map()
        {
            _gameObjectsMap = new GameObject[_xSize, _ySize];            
            FillMap();           
        }

        private void FillMap()
        {
            for (int x = 0; x < _xSize; x++)
            {
                for (int y = 0; y < _ySize; y++)
                {
                    if (x == 0 || y == 0 || x == _xSize - 1 || y == _ySize - 1)
                    {
                        _gameObjectsMap[x, y] = new ConcreteWall();
                    }
                    else if (_rand.Next(15) == 3 || _rand.Next(15) == 5)
                    {
                        _gameObjectsMap[x, y] = new ConcreteWall();
                    }
                    else if (_rand.Next(6) == 1)
                    {
                        if (_rand.Next(1, 5) == 1 || _rand.Next(2, 8) == 5) 
                        {
                            _gameObjectsMap[x, y] = new TempWall(ref TotalAmountOfTempWalls);
                        }
                        else
                        {
                            _gameObjectsMap[x, y] = new StrongTempWall(ref TotalAmountOfTempWalls);
                        }
                    }
                    else if (_rand.Next(10) == 3)
                    {
                        if (_rand.Next(1, 5) == 1)
                        {
                            _gameObjectsMap[x, y] = new ExpensiveCoin();
                        }
                        else
                        {
                            _gameObjectsMap[x, y] = new Coin();
                        }
                    }
                    else
                    {
                        _gameObjectsMap[x, y] = new EmptySpace();
                    }
                }
            }

            PlayerXCoordiante = _rand.Next(1, Constant.WindowXSize - 1);
            PlayerYCoordiante = _rand.Next(1, Constant.WindowYSize - 1);

            _gameObjectsMap[PlayerXCoordiante, PlayerYCoordiante] = new Player();
        }

        public GameObject this[int x, int y]
        {
            get => _gameObjectsMap[x, y];
            set
            {
                _gameObjectsMap[x, y] = value;
            }
        }
    }
}
