using BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class BlustWave : GameObject
    {
        public override char Character { get; set; } = Constant.BlustWaveChar;
        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.Write(Character);
        }

        public override void SetObjectIntoMap(int y, int x)
        {
            var listOfAxisY = new int[] { y - 1, y + 1, x, x };
            var listOfAxisX = new int[] { x - 1, x + 1, y, y };

            for (int i = 0; i <= 1; i++)
            {
                DestroyTempWall(listOfAxisY[i], listOfAxisY[i + 2]);
                base.SetObjectIntoMap(listOfAxisY[i], listOfAxisY[i + 2]);
            }
            for (int i = 0; i <= 1; i++)
            {
                DestroyTempWall(listOfAxisX[i + 2], listOfAxisX[i]);
                base.SetObjectIntoMap(listOfAxisX[i + 2], listOfAxisX[i]);
            }
        }

        private void DestroyTempWall(int y, int x)
        {
            if (Scene[y, x].Character == Constant.TempWallChar)
                TempWall.TotalAmountOfTempWalls--;
        }

        public override bool CanMove(int newY, int newX)
        {
            return false;
        }

        public override void Action(int y, int x){}

        public override bool CanBeDestroyed()
        {
            return true;
        }
    }
}
