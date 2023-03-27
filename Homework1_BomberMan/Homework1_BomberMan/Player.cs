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
        public override char Character { get; } = Constant.PlayerChar;

        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void DrawPlayer()
        {
            Console.CursorLeft = this.X;
            Console.CursorTop = this.Y;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(this.Character);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
