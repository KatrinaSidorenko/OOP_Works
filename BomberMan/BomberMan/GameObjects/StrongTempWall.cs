using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
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
