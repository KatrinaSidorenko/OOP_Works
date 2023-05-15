using Bomberman.GameObjects.Walls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class ConcreteWall : BaseWall
    {
        public override char Character { get; set; } = ConcreteWallChar;

        public override bool CanBeDestroyed => false;

        public override void Draw(int y, int x)
        {
            base.Draw(y, x);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Character);
            Console.ResetColor();
        }
    }
}
