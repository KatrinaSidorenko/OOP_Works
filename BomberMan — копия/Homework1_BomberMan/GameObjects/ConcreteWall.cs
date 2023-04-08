using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class ConcreteWall : GameObject
    {
        public override char Character { get; } = Constant.ConcreteWallChar;
    }
}
