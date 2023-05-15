using Bomberman.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public abstract class GameObject
    {
        protected const char BombChar = '@';
        protected const char ConcreteWallChar = '█';
        protected const char TempWallChar = 'o';
        protected const char EmptySpaceChar = ' ';
        protected const char BlustWaveChar = '.';
        protected const char CoinChar = '♦';
        public abstract char Character { get; set; }
        public abstract bool CanMoveThrough { get; }
        public abstract bool CanBeDestroyed { get; }
        public virtual void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + Constant.BorderIndentX, y + Constant.BorderIndentY);
        }
        public virtual void Action(GameLogic game){} 
    }
}
