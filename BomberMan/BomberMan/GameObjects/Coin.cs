using BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class Coin : GameObject
    {
        public override char Character { get; set; } = Constant.CoinChar;
        private Random _random = new Random();
        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Character);
            Console.ResetColor();
        }

        public override void SetObjectIntoMap( int y, int x)
        {
            var listOfAxisY = new int[] { y - 1, y + 1, x, x};
            var listOfAxisX = new int[] { x - 1, x + 1, y, y};

            for (int i = 0; i <= 1; i++) 
            {
                new EmptySpace().SetObjectIntoMap( listOfAxisY[i], listOfAxisY[i + 2]);
            }
            for (int i = 0; i <= 1; i++)
            {
                new EmptySpace().SetObjectIntoMap(listOfAxisX[i + 2], listOfAxisX[i]);
            }

            base.SetObjectIntoMap(_random.Next(listOfAxisY[0], listOfAxisY[1]), _random.Next(listOfAxisX[0], listOfAxisX[1]));
        }

        public override bool CanMove(int newY, int newX)
        {
            return true;
        }

        public override void Action(int y, int x)
        {
            new EmptySpace().SetObjectIntoMap(y, x); 
            GameProperties.Score++;
        }

        public override bool CanBeDestroyed()
        {
            return true;
        }
    }
}
