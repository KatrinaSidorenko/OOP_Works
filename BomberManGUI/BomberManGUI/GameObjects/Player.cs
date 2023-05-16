using System.Windows.Forms;
using BomberManGUI.Enums;
using BomberManGUI.Engine;
using BomberManGUI.View;

namespace BomberManGUI.GameObjects
{
    public class Player : GameObject
    {
        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => false;       
        public override void Action(GameLogic game)
        {
            game.GameState = GameState.Dead;
        }

        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {            
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = Converter.ObjectTypeToPicture[typeof(EmptySpace)];
        }

    }
}
