using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class BlustWave : GameObject
    {
        public override char Character { get; set; } = BlustWaveChar;

        public override bool CanMoveThrough => false;

        public override bool CanBeDestroyed => true;

        public override void Draw(int y, int x)
        {
            base.Draw(y, x);
            Console.Write(Character);
        }       
    }
}
