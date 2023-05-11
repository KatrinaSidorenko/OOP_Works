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

        private void Swap((int pX, int pY) player, (int x, int y) empty)
        {
            var temp = _map[empty.x, empty.y];

            if (temp is Coin )
            {
                temp = new EmptySpace();
            }

            _map[empty.x, empty.y] = _map[player.pX, player.pY];
            _map[player.pX, player.pY] = temp;
        }

        public void PlayerUpMove(int newX, int newY)
        {
            Swap(player: (newX, newY), empty: (newX, newY - 1));
        }

        public void PlayerDownMove(int newX, int newY)
        {
            Swap(player: (newX, newY), empty: (newX, newY + 1));
        }

        public void PlayerRightMove(int newX, int newY)
        {
            Swap(player: (newX, newY), empty: (newX + 1, newY));
        }

        public void PlayerLeftMove(int newX, int newY)
        {
            Swap(player: (newX, newY), empty: (newX - 1, newY));
        }
        public void CreateBomb(int x, int y)
        {
            _map[x, y] = new Bomb();            
        }

        private void CreateObjectsHelper(List<(int, int)> coordinates, Type objType)
        {
            foreach (var coord in coordinates)
            {
                _map[coord.Item1, coord.Item2] = (GameObject)Activator.CreateInstance(objType);
            }
        }

        public void CreateBlustWave(List<(int, int)> coordinates)
        {
            CreateObjectsHelper(coordinates, new BlustWave().GetType()); 
        }

        public void ClearBombSurrounding(List<(int, int)> coordinates)
        {
            CreateObjectsHelper(coordinates, new EmptySpace().GetType());
        }
    }
}
