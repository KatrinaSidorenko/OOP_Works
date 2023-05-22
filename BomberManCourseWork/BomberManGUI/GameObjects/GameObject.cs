using BomberManGUI.Engine;
using BomberManGUI.View;
using System;

namespace BomberManGUI.GameObjects
{
    public abstract class GameObject
    {
        public abstract bool CanMoveThrough { get; }
        public abstract bool CanBeDestroyed { get; }
        public virtual void Draw(BaseSceneManager drawer, int x, int y)
        {
        }
        public virtual void Action(GameLogic game) {}
    }
}
