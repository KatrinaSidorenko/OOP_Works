using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class TempWall : GameObject
    {
        public TempWall(ref int amount)
        {
            amount++;
        }
        public override char Character { get; set; } = Constant.TempWallChar;

        public override bool CanMoveThrough => false;

        public override bool CanBeDestroyed => true;

        public override void Action(GameLogic game)
        {
            game.Walls--;
        }

        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.Write(Character);
        }
    }
}
