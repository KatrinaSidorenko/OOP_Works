using BomberManGUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberManGUI.View
{
    public abstract class BaseSceneManager
    {
        public abstract void DrawStartScene();
        public abstract void DrawObject(Type type, int x, int y);
        public abstract Map PhisicMap { get; set; }
        public abstract void DrawPlayerMove(Direction direction, int x, int y);
        public abstract void DrawBomb(int x, int y);
        public abstract void BaseObjectsDrawer(List<(int, int)> coordinates, Type objType);
        public abstract void DrawBlustWave(List<(int, int)> coordinates);
        public abstract void DrawEmptySpaces(List<(int, int)> coordinates, (int, int) newCoinCoordinates);
        public abstract void PlayMusic();
    }
}
