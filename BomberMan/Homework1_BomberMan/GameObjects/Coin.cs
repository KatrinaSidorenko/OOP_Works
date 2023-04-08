using Homework1_BomberMan;
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

        public override void SetObjectIntoMap(Map map, int y, int x)
        {
            if (map[y - 1, x].Character == Constant.BlustWaveChar)
            {
                CreateCoin(map, y - 1, x);
            }
            if (map[y + 1, x].Character == Constant.BlustWaveChar)
            {
                CreateCoin(map, y + 1, x);
            }
            if (map[y, x - 1].Character == Constant.BlustWaveChar)
            {
                CreateCoin(map, y , x - 1);
            }
            if (map[y, x + 1].Character == Constant.BlustWaveChar)
            {
                CreateCoin(map, y, x + 1);
            }
        }

        private void CreateCoin(Map map, int y, int x)
        {
            if (_random.Next(5) == 1)
            {
                base.SetObjectIntoMap(map, y, x);
            }
            else
            {
                new EmptySpace().SetObjectIntoMap(map, y, x);
            }
        }
    }
}
