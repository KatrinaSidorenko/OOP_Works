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
    public class TempWall : GameObject
    {
        public virtual int Strengh { get; set; } = 1;
        public TempWall(ref int amount)
        {
            amount++;
        }

        public override bool CanMoveThrough => false;

        public override bool CanBeDestroyed => true;

        public override void Action(GameLogic game, GameMovements movements, int x, int y)
        {
            Strengh--;

            if (Strengh == 0)
            {
                game.Walls--;               
            }            
        }

        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {            
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = BomberManGUI.Properties.Resources.brick;
        }
        
    }
}
