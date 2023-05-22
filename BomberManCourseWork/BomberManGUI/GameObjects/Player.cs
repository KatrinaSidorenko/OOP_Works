using System.Windows.Forms;
using BomberManGUI.Enums;
using BomberManGUI.Engine;
using BomberManGUI.View;

namespace BomberManGUI.GameObjects
{
    public class Player : GameObject
    {
        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => false;       
        public override void Action(GameLogic game)
        {
            game.GameState = GameState.Dead;
        }
        public override void Draw(BaseSceneManager drawer, int x, int y)
        {
            drawer.DrawObject(typeof(Player), x, y);
        }

    }
}
