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
    public abstract class GameObject
    {
        public abstract bool CanMoveThrough { get; }
        public abstract bool CanBeDestroyed { get; }
        public virtual void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {            
        }
        public virtual void Action(GameLogic game, GameMovements movements, int x, int y) {} 

        protected PictureBox PictureBoxCreation(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {
            PictureBox picture = new PictureBox();
            picture.Location = new Point(x * (boxSize - 1), y * (boxSize - 1));
            picture.Size = new Size(boxSize, boxSize);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;

            mapPics[x, y] = picture;
            gamePanel.Controls.Add(picture);

            return picture;
        }
    }
}
