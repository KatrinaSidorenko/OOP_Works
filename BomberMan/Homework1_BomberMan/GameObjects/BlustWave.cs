using Homework1_BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class BlustWave : GameObject
    {
        public override char Character { get; set; } = Constant.BlustWaveChar;
        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.Write(Character);
        }

        public override void SetObjectIntoMap(Map map, int y, int x)
        {
            if (map[y - 1, x].Character != Constant.ConcreteWallChar)
            {
                if (map[y - 1, x].Character == Constant.TempWallChar) 
                    TempWall.TotalAmountOfTempWalls--;
                base.SetObjectIntoMap(map, y - 1, x);
            }
            if (map[y + 1, x].Character != Constant.ConcreteWallChar)
            {
                if (map[y - 1, x].Character == Constant.TempWallChar) 
                    TempWall.TotalAmountOfTempWalls--;
                base.SetObjectIntoMap(map, y + 1, x);
            }
            if (map[y, x + 1].Character != Constant.ConcreteWallChar)
            {
                if (map[y - 1, x].Character == Constant.TempWallChar) 
                    TempWall.TotalAmountOfTempWalls--;
                base.SetObjectIntoMap(map, y, x + 1);
            }
            if (map[y, x - 1].Character != Constant.ConcreteWallChar)
            {
                if (map[y - 1, x].Character == Constant.TempWallChar)
                    TempWall.TotalAmountOfTempWalls--;
                base.SetObjectIntoMap(map, y, x - 1);
            }
        }

        
    }
}
