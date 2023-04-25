using System;
using Bomberman;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class Player : GameObject
    {
        public override char Character { get; set; } 
        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => false;
        public Player()
        {
            Character = FileManager.GetCharacter();
        }
        public override void Action(GameLogic game)
        {
            game.Condition = GameCondition.Dead;
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
