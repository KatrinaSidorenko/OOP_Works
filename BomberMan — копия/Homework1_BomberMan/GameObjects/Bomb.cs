using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class Bomb : GameObject
    {
        public override char Character { get;} = Constant.BombChar;
        private Map _bombMap;
        private Thread _thread;
        private Player _player;
        public Bomb(Player player, Map map)
        {
            this.X = player.X;
            this.Y = player.Y;
            _bombMap = map;
            _player = player;
            SetBombIntoMap();

            _thread = new Thread(new ThreadStart(CreateBlustWave));
            _thread.Start();
        }

        public void SetBombIntoMap()
        {
            _bombMap[this.Y, this.X] = this;

        }

        private void DeleteBombSurrounding()
        {
            _bombMap[this.Y, this.X] = new EmptySpace();

            CheckBombSurrounding(Y + 1, X, 1);
            CheckBombSurrounding(Y - 1, X, 1);
            CheckBombSurrounding(Y, X - 1, 1);
            CheckBombSurrounding(Y, X + 1, 1);
        }

        public void CreateBlustWave()
        {
            Thread.Sleep(2000);

            CheckBombSurrounding(Y + 1, X, 0);
            CheckBombSurrounding(Y - 1, X, 0);
            CheckBombSurrounding(Y, X - 1, 0);
            CheckBombSurrounding(Y, X + 1, 0);

            _player.PlayerDeath(_bombMap);

            Thread.Sleep(1000);

            DeleteBombSurrounding();
        }
        public void CheckBombSurrounding(int y, int x, int condition)
        {
            switch (condition)
            {
                case 0:
                    if (_bombMap[y, x].Character != Constant.ConcreteWallChar)
                    {
                        _bombMap[y, x] = new BlustWave();
                    }
                    break;
                case 1:
                    if (_bombMap[y, x].Character == Constant.BlustWaveChar)
                    {
                        _bombMap[y, x] = new EmptySpace();
                    }
                    break;
            }
            
        }
    } 
}
