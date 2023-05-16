using BomberManGUI.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomberManGUI.GameObjects
{
    public class Bomb : GameObject
    {
        public override bool CanMoveThrough => false;

        public override bool CanBeDestroyed => false;
        
    }
}
