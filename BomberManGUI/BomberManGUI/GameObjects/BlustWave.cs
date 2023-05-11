using BomberManGUI.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman.GameObjects
{
    public class BlustWave : GameObject
    {
        public override bool CanMoveThrough => false;

        public override bool CanBeDestroyed => true;
    }
}
