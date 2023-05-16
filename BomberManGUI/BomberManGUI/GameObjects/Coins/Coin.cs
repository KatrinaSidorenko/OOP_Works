using BomberManGUI.Engine;
using BomberManGUI.Enums;
using System.Windows.Forms;
using BomberManGUI.View;

namespace BomberManGUI.GameObjects
{
    public class Coin : GameObject
    {

        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => true;

        public override void Action(GameLogic game)
        {
            game.Score++;
            
        }
        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {            
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = Converter.ObjectTypeToPicture[typeof(Coin)];
        }
    }
}
