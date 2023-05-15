using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects.Walls
{
    public abstract class BaseWall : GameObject
    {
        public override bool CanMoveThrough => false;
    }
}
