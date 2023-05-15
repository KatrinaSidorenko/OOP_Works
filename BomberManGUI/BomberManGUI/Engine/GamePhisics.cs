using Bomberman.GameObjects;
using BomberManGUI.Enums;
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

        private void Swap((int pX, int pY) player, (int x, int y) newPlayerCoordinates)
        {
            var temp = _map[newPlayerCoordinates.x, newPlayerCoordinates.y];

            if (temp is Coin)
            {
                temp = new EmptySpace();
            }

            _map[newPlayerCoordinates.x, newPlayerCoordinates.y] = _map[player.pX, player.pY];
            _map[player.pX, player.pY] = temp;
        }

        public void PlayerPhisicMove(int y, int x, Direction direction)
        {
            int newY = y + Converter.DirectionToCoordinates[direction].dy;
            int newX = x + Converter.DirectionToCoordinates[direction].dx;

            Swap(player: (x, y), newPlayerCoordinates: (newX, newY));
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
