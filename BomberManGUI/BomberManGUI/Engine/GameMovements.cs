using Bomberman;
using BomberManGUI.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomberManGUI.Engine
{
    public class GameMovements
    {
        private PictureBox _player;
        public PictureBox[,] _imgMap;

        public GameMovements(PictureBox[,] map, PictureBox player) 
        { 
            _imgMap = map;
            _player = player;
        }

        public void PlayerMove(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    _player.Location = new Point(_player.Location.X - MainBoard.BoxSize + 1, _player.Location.Y);
                    break;
                case Direction.Right:
                    _player.Location = new Point(_player.Location.X + MainBoard.BoxSize - 1, _player.Location.Y);
                    break;
                case Direction.Up:
                    _player.Location = new Point(_player.Location.X, _player.Location.Y - MainBoard.BoxSize + 1);
                    break;
                case Direction.Down:
                    _player.Location = new Point(_player.Location.X, _player.Location.Y + MainBoard.BoxSize - 1);
                    break;
                default:
                    break;
            }
        }

        public void CoinCollection(int x, int y)
        {
            _imgMap[x, y].Image = Properties.Resources.ground;
        }


        public void BombCreation(int x, int y)
        {
            _imgMap[x, y].Image = Properties.Resources.bomb;
        }

        public void BlustWaveCreation(List<(int, int)> coordinates)
        {
            foreach(var coordinate in coordinates) 
            {
                _imgMap[coordinate.Item1, coordinate.Item2].Image = Properties.Resources.fire;
            }
        }

        public void ClearBombSurrounding(List<(int, int)> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                _imgMap[coordinate.Item1, coordinate.Item2].Image = Properties.Resources.ground;
            }
        }
    }
}
