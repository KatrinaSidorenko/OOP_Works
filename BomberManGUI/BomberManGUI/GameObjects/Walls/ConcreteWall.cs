using BomberManGUI.Enums;
using System.Windows.Forms;

namespace BomberManGUI.GameObjects.Walls
{
    public class ConcreteWall : BaseWall
    {        

        public override bool CanBeDestroyed => false;

        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {          
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = Converter.ObjectTypeToPicture[typeof(ConcreteWall)];
        }
    }
}
