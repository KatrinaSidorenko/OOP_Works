using BomberManGUI.GameObjects;
using BomberManGUI.GameObjects.Walls;
using BomberManGUI.View;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static Dictionary<Direction, (int dx, int dy)> DirectionToCoordinates = new Dictionary<Direction, (int dy, int dx)>
        {
            { Direction.Up, (0, -1) },
            { Direction.Down, (0, 1) },
            { Direction.Right, (1, 0) },
            { Direction.Left, (-1, 0) }
        };

        public static Dictionary<Direction, (int pointX, int pointY)> DirectionToPointCoordinates = new Dictionary<Direction, (int pointX, int pointY)>
        {
            { Direction.Up, (0, - SceneDrawer.BoxSize + 1) },
            { Direction.Down, (0, + SceneDrawer.BoxSize - 1) },
            { Direction.Right, (+ SceneDrawer.BoxSize - 1, 0) },
            { Direction.Left, (- SceneDrawer.BoxSize + 1, 0) }
        };

        public static Dictionary<Type, Bitmap> ObjectTypeToPicture = new Dictionary<Type, Bitmap>()
        {            
            {typeof(Player),  Properties.Resources.Bomber },
            {typeof(TempWall), Properties.Resources.brick },
            {typeof(Coin), Properties.Resources.coin },
            {typeof(ExpensiveCoin), Properties.Resources.diamand },
            {typeof(BlustWave), Properties.Resources.fire },
            {typeof(EmptySpace), Properties.Resources.ground },
            {typeof(Bomb), Properties.Resources.bomb },
            {typeof(ConcreteWall), Properties.Resources.concreteWall }
        };
    }
}
