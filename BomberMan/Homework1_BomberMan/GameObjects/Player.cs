using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class Player : GameObject
    {
        public override char Character { get; set; }
        public Player()
        {
            var rand = new Random();
            this.X = rand.Next(1, Constant.WindowXSize - 1);
            this.Y = rand.Next(1, Constant.WindowYSize - 1);
        }

        public void PlayerState(int x, int y, Map map)
        {
            if (map[y, x].Character == Constant.EmptySpaceChar)
            {
                X = x;
                Y = y;
            }
            if (map[y, x].Character == Constant.CoinChar)
            {
                map[y, x] = new EmptySpace();
                Score++;
            }
        }

        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(Character);
            Console.ResetColor();
        }

        
    }
}
