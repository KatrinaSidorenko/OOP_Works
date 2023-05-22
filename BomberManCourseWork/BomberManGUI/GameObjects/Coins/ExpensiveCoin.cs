using BomberManGUI.Engine;
using BomberManGUI.Enums;
using BomberManGUI.View;
using System.Windows.Forms;

namespace BomberManGUI.GameObjects
{
    public class ExpensiveCoin : Coin
    {
        public override void Action(GameLogic game)
        {
            game.Score += 2;
        }
        public override void Draw(BaseSceneManager drawer, int x, int y)
        {
            drawer.DrawObject(typeof(ExpensiveCoin), x, y);
        }

    }
}
