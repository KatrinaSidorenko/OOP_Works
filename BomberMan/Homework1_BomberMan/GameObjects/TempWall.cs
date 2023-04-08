using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class TempWall : GameObject
    {
        public override char Character { get; set; } = Constant.TempWallChar;
        public static int TotalAmountOfTempWalls;

        public TempWall() 
        {
            TotalAmountOfTempWalls += 1;
        }
        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.Write(Character);
        }
    }
}
