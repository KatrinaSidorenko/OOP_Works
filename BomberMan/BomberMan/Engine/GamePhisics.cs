using Bomberman.Enums;
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

        private void Swap((int pY, int pX)player, (int y, int x)newPlayerCoordinates)
        {
            var temp = _map[newPlayerCoordinates.y, newPlayerCoordinates.x];

            if(temp is Coin)
            {
                temp = new EmptySpace();
            }

            _map[newPlayerCoordinates.y, newPlayerCoordinates.x] = _map[player.pY, player.pX];
            _map[player.pY, player.pX] = temp;
        }

        public void PlayerPhisicMove((int y, int x)player, (int newY, int newX)newCoordinates)
        {
            Swap(player: (player.y, player.x), newPlayerCoordinates:(newCoordinates.newY, newCoordinates.newX));
        }
        
        public void CreateBomb(int y, int x)
        {
            _map[y, x] = new Bomb();            
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
