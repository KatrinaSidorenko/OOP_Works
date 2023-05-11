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
    public class StrongTempWall : TempWall
    {
        public override int Strengh { get; set; } = 2;
        public StrongTempWall(ref int amount) : base(ref amount)
        {
        }
        public override void Action(GameLogic game, GameMovements movements, int x, int y)
        {
            base.Action(game,movements, x, y);
        }       
    }
}
