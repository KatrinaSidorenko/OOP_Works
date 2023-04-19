using Bomberman.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bomberman
{
    public class GamePhisics
    {
        private Map _map;
        public GamePhisics(Map map)
        {
            _map = map;
        }

        private void Swap((int pY, int pX)player, (int y, int x)empty)
        {
            var temp = _map[empty.y, empty.x];

            if(temp is Coin)
            {
                temp = new EmptySpace();
            }

            _map[empty.y, empty.x] = _map[player.pY, player.pX];
            _map[player.pY, player.pX] = temp;
        }

        public void PlayerUpMove(int newY, int newX)
        {
            Swap(player: (newY, newX), empty: (newY - 1, newX));
        }

        public void PlayerDownMove(int newY, int newX)
        {
            Swap(player: (newY, newX), empty: (newY + 1, newX));
        }

        public void PlayerRightMove(int newY, int newX)
        {
            Swap(player: (newY, newX), empty: (newY, newX + 1));
        }

        public void PlayerLeftMove(int newY, int newX)
        {
            Swap(player: (newY, newX), empty: (newY, newX - 1));
        }
        public void CreateBomb(int y, int x)
        {
            _map[y, x] = new Bomb();            
        }

        public void CreateBlustWave(List<(int, int)> coordibates)
        {
            foreach (var coord in coordibates)
            {
                _map[coord.Item1, coord.Item2] = new BlustWave();
            }

            Thread.Sleep(1000);

            foreach (var coord in coordibates)
            {
                _map[coord.Item1, coord.Item2] = new EmptySpace();
            }
        }
    }
}
