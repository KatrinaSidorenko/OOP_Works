using BomberManGUI.View;
using BomberManGUI.Enums;
using BomberManGUI.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomberManGUI.GameObjects.Walls;
using System.Drawing;
using BomberManGUI.Helpers;
using BomberManGUI;
using System.IO;

namespace BomberMan
{
    public class ConsoleSceneManager : BaseSceneManager
    {
        public override Map PhisicMap { get; set; }
        private int _sizeX = Constant.WindowXSize;
        private int _sizeY = Constant.WindowYSize;
        private Dictionary<Type, char> _typeToCharacter = new Dictionary<Type, char>()
        {
            {typeof(Player), 'I' },
            {typeof(EmptySpace), ' ' },
            { typeof(Bomb), '@' },
            {typeof(Coin), '♦' },
            {typeof(BlustWave), '.' },
            {typeof(ConcreteWall), '█' },
            {typeof(ExpensiveCoin), '*' },
            {typeof(TempWall), 'o' }
        };

        public  ConsoleSceneManager()
        {
            PhisicMap = new Map();
        }

        public override void DrawStartScene()
        {
            for (var x = 0; x < _sizeX; x++)
            {
                for (var y = 0; y < _sizeY; y++)
                {
                    PhisicMap[x, y].Draw(this, x, y);
                }
            }

            CreatePlayer();
        }

        public void CreatePlayer()
        {
            Console.SetCursorPosition(PhisicMap.PlayerXCoordiante, PhisicMap.PlayerYCoordiante);
            Console.Write(_typeToCharacter[typeof(EmptySpace)]);
        }

        public override void DrawObject(Type type, int x, int y)
        {
            Console.SetCursorPosition(x,y );
            Console.Write(_typeToCharacter[type]);
        }

        public override void DrawPlayerMove(Direction direction, int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(_typeToCharacter[typeof(EmptySpace)]);
            Console.SetCursorPosition(x + BaseConverter.DirectionToCoordinates[direction].dx, y + BaseConverter.DirectionToCoordinates[direction].dy);
            Console.Write(_typeToCharacter[typeof (Player)]);
        }
        public override void DrawBomb(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(_typeToCharacter[typeof(Bomb)]);
        }

        public override void BaseObjectsDrawer(List<(int, int)> coordinates, Type objType)
        {
            foreach (var coordinate in coordinates)
            {
                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2);
                Console.Write(_typeToCharacter[objType]);
            }
        }

        public override void DrawBlustWave(List<(int, int)> coordinates)
        {
            BaseObjectsDrawer(coordinates, typeof(BlustWave));
        }

        public override void DrawEmptySpaces(List<(int, int)> coordinates)
        {
            BaseObjectsDrawer(coordinates, typeof(EmptySpace));
        }

        public override void PlayMusic()
        {
        }
    }
}
