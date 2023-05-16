using BomberManGUI.Engine;
using BomberManGUI.Enums;
using System.Windows.Forms;

namespace BomberManGUI.GameObjects
{
    public class ExpensiveCoin : Coin
    {
        public override void Action(GameLogic game)
        {
            game.Score += 2;
        }

        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {           
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = Converter.ObjectTypeToPicture[typeof(ExpensiveCoin)]; ;
        }

    }
}
