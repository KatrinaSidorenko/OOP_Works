using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public abstract class GameObject
    {
        protected int X { get; set; }
        protected int Y { get; set; }
        public abstract char Character { get; }
    }
}
