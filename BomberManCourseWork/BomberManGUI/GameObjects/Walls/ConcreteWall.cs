using BomberManGUI.Enums;
using BomberManGUI.View;
using System.Windows.Forms;

namespace BomberManGUI.GameObjects.Walls
{
    public class ConcreteWall : BaseWall
    {        

        public override bool CanBeDestroyed => false;
        public override void Draw(BaseSceneManager drawer, int x, int y)
        {
            drawer.DrawObject(typeof(ConcreteWall), x, y);
        }
    }
}
