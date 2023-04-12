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
        public static  GameObject[,] Scene { get; set; }
        public abstract char Character { get; set; }
        public abstract void Draw(int y, int x);

        public void Start(ref GameObject[,] scene)
        {
            Scene = scene;
        }

        public virtual void SetObjectIntoMap(int y, int x) 
        {
            if (Scene[y, x].CanBeDestroyed())
            {
                Scene[y, x] = this;
            }
        }

        public abstract void Action(int y, int x);
        public abstract bool CanMove(int newY, int newX);

        public abstract bool CanBeDestroyed();
    }
}