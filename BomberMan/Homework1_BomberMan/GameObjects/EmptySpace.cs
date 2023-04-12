using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class EmptySpace : GameObject
    {
        public override char Character { get; set; } = Constant.EmptySpaceChar;
        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.Write(Character);
        }

        public override bool CanMove(int newY, int newX)
        {
            return true;
        }

        public override void SetObjectIntoMap( int y, int x)
        {
            base.SetObjectIntoMap( y, x);
        }

        public override void Action(int y, int x)
        {
          
        }

        public override bool CanBeDestroyed()
        {
            return true;
        }
    }
}
