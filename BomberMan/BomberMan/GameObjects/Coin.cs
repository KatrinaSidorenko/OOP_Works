using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class Coin : GameObject
    {
        public override char Character { get; set; } = Constant.CoinChar;

        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => true;

        public override void Action(GameLogic game)
        {
            game.Score++;
        }

        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Character);
            Console.ResetColor();
        }
    }
}
