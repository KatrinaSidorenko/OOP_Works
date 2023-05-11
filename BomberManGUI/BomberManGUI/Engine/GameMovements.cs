using Bomberman;
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

        public void PlayerMove(PlayerAction direction)
        {
            switch (direction)
            {
                case PlayerAction.Left:
                    _player.Location = new Point(_player.Location.X - MainBoard.BoxSize + 1, _player.Location.Y);
                    break;
                case PlayerAction.Right:
                    _player.Location = new Point(_player.Location.X + MainBoard.BoxSize - 1, _player.Location.Y);
                    break;
                case PlayerAction.Up:
                    _player.Location = new Point(_player.Location.X, _player.Location.Y - MainBoard.BoxSize + 1);
                    break;
                case PlayerAction.Down:
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
