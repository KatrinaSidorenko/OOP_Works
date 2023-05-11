using System;
using Bomberman;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BomberManGUI.Engine;

namespace Bomberman.GameObjects
{
    public class Player : GameObject
    {
        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => false;       
        public override void Action(GameLogic game, GameMovements movements, int x, int y)
        {
            game.Condition = GameCondition.Dead;
        }

        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {            
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = BomberManGUI.Properties.Resources.ground;
        }

    }
}
