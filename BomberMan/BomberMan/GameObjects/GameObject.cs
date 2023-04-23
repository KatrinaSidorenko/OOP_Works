using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.GameObjects
{
    public abstract class GameObject
    {
        public abstract char Character { get; set; }
        public abstract bool CanMoveThrough { get; }
        public abstract bool CanBeDestroyed { get; }
        public abstract void Draw(int y, int x);
        public virtual void Action(GameLogic game){} 
    }
}
