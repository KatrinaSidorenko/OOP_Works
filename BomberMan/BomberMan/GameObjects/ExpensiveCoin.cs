using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class ExpensiveCoin : Coin
    {
        public override void Action(GameLogic game)
        {
            game.Score += 2;
        }

        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Character);
            Console.ResetColor();
        }
    }
}
