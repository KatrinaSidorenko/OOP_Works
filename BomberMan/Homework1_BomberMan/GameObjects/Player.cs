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
            X = rand.Next(1, Constant.WindowXSize - 1);
            Y = rand.Next(1, Constant.WindowYSize - 1);
        }

        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(Character);
            Console.ResetColor();
        }

        public void PlayerAction(int newY, int newX)
        {
            Scene[newY, newX].Action(newY, newX);

            if (Scene[newY, newX].CanMove(newY, newX))
            {
                this.X = newX;
                this.Y = newY;
            }             
        }

        public override bool CanMove(int newY, int newX)
        {
            return false;
        }

        public override void Action(int y, int x)
        {
            
        }

        public override bool CanBeDestroyed()
        {
            return false;
        }
    }
}
