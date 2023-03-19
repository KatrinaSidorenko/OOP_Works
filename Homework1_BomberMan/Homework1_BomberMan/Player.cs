using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class Player : GameObject
    {
        public override char Character { get; set; } = Constant.PlayerChar;

        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
