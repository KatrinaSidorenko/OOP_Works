using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class Player : GameObject
    {
        public override char Character { get; } = Constant.PlayerChar;
        public GameCondition Condition { get; set; }
        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void PlayerState(int x, int y, Map map)
        {
            if (map[y, x].Character == Constant.EmptySpaceChar)
            {
                X = x;
                Y = y;
            }
        }

        public void PlayerDeath(Map map)
        {
            if (map[Y, X].Character == Constant.BombChar || map[Y, X].Character == Constant.BlustWaveChar)
            {
                Condition = GameCondition.End;
            }
        }
    }
}
