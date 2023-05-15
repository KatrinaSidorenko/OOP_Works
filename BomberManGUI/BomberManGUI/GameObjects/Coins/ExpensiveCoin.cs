using BomberManGUI.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman.GameObjects
{
    public class ExpensiveCoin : Coin
    {
        public override void Action(GameLogic game, GameMovements movements, int x, int y)
        {
            game.Score += 2;
            movements.CoinCollection(x, y);
        }

        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {           
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = BomberManGUI.Properties.Resources.diamand;
        }

    }
}
