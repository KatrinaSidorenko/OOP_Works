using BomberManGUI.Engine;
using BomberManGUI.Enums;
using System.Windows.Forms;
using BomberManGUI.View;

namespace BomberManGUI.GameObjects
{
    public class Coin : GameObject
    {
        //public Coin(ref int totalCoins)
        //{
        //    totalCoins++;
        //}

        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => true;

        public override void Action(GameLogic game)
        {
            game.Score++;
            if(game.CoinsAmount != 0)
            {
                game.CoinsAmount--;
            }         
        }
        public override void Draw(BaseSceneManager drawer, int x, int y)
        {
            drawer.DrawObject(typeof(Coin), x, y);
        }
    }
}
