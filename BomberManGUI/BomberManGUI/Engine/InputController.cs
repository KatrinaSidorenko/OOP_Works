using Bomberman.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public class InputController
    {
        public PlayerAction GetInput(Keys ki)
        {
            switch (ki)
            {
                case Keys.Escape:
                    return PlayerAction.End;
                case Keys.Space:
                    return PlayerAction.Bomb;
                case Keys.Left:
                    return PlayerAction.Left;
                case Keys.Right:
                    return PlayerAction.Right;
                case Keys.Up:
                    return PlayerAction.Up;
                case Keys.Down:
                    return PlayerAction.Down;
            }

            return PlayerAction.None;
        }
    }
}
