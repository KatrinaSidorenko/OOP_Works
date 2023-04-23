using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class Bomb : GameObject
    {
        public override char Character { get; set; } = Constant.BombChar;

        public override bool CanMoveThrough => false;

        public override bool CanBeDestroyed => false;       

        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.Write(Character);
        }

    }
}
