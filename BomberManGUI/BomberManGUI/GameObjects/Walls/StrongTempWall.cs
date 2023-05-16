using BomberManGUI.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomberManGUI.View;
using System.Windows.Forms;

namespace BomberManGUI.GameObjects.Walls
{
    public class StrongTempWall : TempWall
    {
        public override int Strengh { get; set; } = 2;
        public StrongTempWall(ref int amount) : base(ref amount)
        {
        }
        public override void Action(GameLogic game)
        {
            base.Action(game);
        }       
    }
}
