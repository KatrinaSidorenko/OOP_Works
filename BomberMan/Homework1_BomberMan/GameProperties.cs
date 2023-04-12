using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class GameProperties
    {
        public static GameCondition Condition { get; set; } = GameCondition.InProgress;
        public static int Score { get; set; }
    }
}
