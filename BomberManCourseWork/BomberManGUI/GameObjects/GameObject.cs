using BomberManGUI;
using BomberManGUI.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BomberManGUI.View;

namespace BomberManGUI.GameObjects
{
    public abstract class GameObject
    {
        public abstract bool CanMoveThrough { get; }
        public abstract bool CanBeDestroyed { get; }
        public virtual void Draw(SceneDrawer drawer, int x, int y)
        {
        }
        public virtual void Action(GameLogic game) {} 
    }
}
