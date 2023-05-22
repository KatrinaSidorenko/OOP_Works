using BomberManGUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomberManGUI.Engine
{
    public abstract class BaseInputController
    {
        //public abstract PlayerAction GetInput(Keys ki);
        public abstract PlayerAction GetInput();
    }
}
