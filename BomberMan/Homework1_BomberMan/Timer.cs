using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class Timer
    {
        private DateTime _startTime;
        private TimeSpan _duration = new TimeSpan(0, 1, 0);
        public Timer()
        {
            _startTime = DateTime.Now;
        }

        public void GemaOverCheck(Player player)
        {
            if (DateTime.Now - _startTime > _duration)
            {
                player.Condition = GameCondition.End;
            }
        }
    }
}
