using BomberManGUI.Engine;
using BomberManGUI.Enums;
using BomberManGUI.View;
using System.Windows.Forms;

namespace BomberManGUI.GameObjects.Walls
{
    public class TempWall : BaseWall
    {
        public virtual int Strengh { get; set; } = 1;
        public TempWall(ref int amount)
        {
            amount++;
        }
        public override bool CanBeDestroyed => true;

        public override void Action(GameLogic game)
        {
            Strengh--;

            if (Strengh == 0)
            {
                game.Walls--;               
            }            
        }
        public override void Draw(BaseSceneManager drawer, int x, int y)
        {
            drawer.DrawObject(typeof(TempWall), x, y);
        }

    }
}
