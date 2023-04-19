using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class Player : GameObject
    {
        public Player()
        {
            SetCharacter();
        }
        public override char Character { get; set; } 
        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => false;

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

        private void SetCharacter()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Lenovo\\Desktop\\OOP_Works\\BomberMan\\BomberMan\\PlayerProperties.txt");
            char character = char.Parse(sr.ReadLine());
            Character = character;
            sr.Close();
        }
    }
}
