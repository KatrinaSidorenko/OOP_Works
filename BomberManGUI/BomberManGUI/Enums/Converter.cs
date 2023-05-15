using Bomberman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberManGUI.Enums
{
    public static class Converter
    {
        public static Dictionary<PlayerAction, Direction> ActionToDirection = new Dictionary<PlayerAction, Direction>()
        {
            { PlayerAction.Up, Direction.Up },
            { PlayerAction.Down, Direction.Down },
            { PlayerAction.Left, Direction.Left },
            { PlayerAction.Right, Direction.Right },
        };

        public static Dictionary<Direction, (int dy, int dx)> DirectionToCoordinates = new Dictionary<Direction, (int dy, int dx)>
        {
            { Direction.Up, (-1, 0) },
            { Direction.Down, (1, 0) },
            { Direction.Right, (0, 1) },
            { Direction.Left, (0, -1) }
        };
    }
}
