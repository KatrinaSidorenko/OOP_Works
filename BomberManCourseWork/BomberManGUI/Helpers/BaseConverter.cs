using BomberManGUI.Enums;
using BomberManGUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberManGUI.Helpers
{
    public abstract class BaseConverter
    {
        public static Dictionary<PlayerAction, Direction> ActionToDirection = new Dictionary<PlayerAction, Direction>()
        {
            { PlayerAction.Up, Direction.Up },
            { PlayerAction.Down, Direction.Down },
            { PlayerAction.Left, Direction.Left },
            { PlayerAction.Right, Direction.Right },
        };

        public static Dictionary<Direction, (int dx, int dy)> DirectionToCoordinates = new Dictionary<Direction, (int dy, int dx)>
        {
            { Direction.Up, (0, -1) },
            { Direction.Down, (0, 1) },
            { Direction.Right, (1, 0) },
            { Direction.Left, (-1, 0) }
        };
    }
}
