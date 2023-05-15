using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class EmptySpace : GameObject
    {
        public override char Character { get; set; } = EmptySpaceChar;

        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => true;

        public override void Draw(int y, int x)
        {
            base.Draw(y, x);
            Console.Write(Character);
        }
    }
}
