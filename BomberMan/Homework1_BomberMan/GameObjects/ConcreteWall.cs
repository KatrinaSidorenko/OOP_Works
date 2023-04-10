using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class ConcreteWall : GameObject
    {
        public override char Character { get; set; } = Constant.ConcreteWallChar;
        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(Character);
            Console.ResetColor();
        }
    }
}
