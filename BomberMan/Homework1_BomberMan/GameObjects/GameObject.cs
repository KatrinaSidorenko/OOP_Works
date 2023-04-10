using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static GameCondition Condition { get; set; }
        public int Score { get; set; }
        public abstract char Character { get; set; }

        public abstract void Draw(int y, int x);
        
        public virtual void SetGameCondition(Map map)
        {
            Condition = GameCondition.InProgress;
        }

        public virtual void SetObjectIntoMap(Map map, int y, int x) 
        {
            map[y, x] = this;
        }
    }
}