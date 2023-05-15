using Bomberman.GameObjects.Walls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public class TempWall : BaseWall
    {
        public virtual int Strength { get; set; } = 1;
        public TempWall(ref int amount)
        {
            amount++;
        }
        public override char Character { get; set; } = TempWallChar;

        public override bool CanBeDestroyed => true;


        public override void Action(GameLogic game)
        {
            Strength--;
            if (Strength == 0)
            {
                game.Walls--;               
            }            
        }

        public override void Draw(int y, int x)
        {
            base.Draw(y, x);
            Console.Write(Character);
        }
    }
}
