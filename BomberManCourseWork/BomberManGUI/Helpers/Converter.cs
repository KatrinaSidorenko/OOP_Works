using BomberManGUI.GameObjects;
using BomberManGUI.GameObjects.Walls;
using BomberManGUI.Helpers;
using BomberManGUI.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberManGUI.Enums
{
    public class Converter : BaseConverter
    {
       
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

        public static Dictionary<Direction, (int pointX, int pointY)> DirectionToPointCoordinates = new Dictionary<Direction, (int pointX, int pointY)>
        {
            { Direction.Up, (0, - SceneManager.BoxSize + 1) },
            { Direction.Down, (0, + SceneManager.BoxSize - 1) },
            { Direction.Right, (+ SceneManager.BoxSize - 1, 0) },
            { Direction.Left, (- SceneManager.BoxSize + 1, 0) }
        };
    }
}
