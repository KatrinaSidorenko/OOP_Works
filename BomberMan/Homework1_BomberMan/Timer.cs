using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void GemaOverTimeCheck()
        {
            if (DateTime.Now - _startTime > _duration && TempWall.TotalAmountOfTempWalls == 0)
            {
                GameObject.Condition = GameCondition.Victory;
            }
            else if(DateTime.Now - _startTime > _duration)
            {
                GameObject.Condition = GameCondition.TimeLeftEnd;
            }
        }

        public TimeSpan GetRestOfTheTime()
        {
            return _duration - (DateTime.Now - _startTime);
        }
    }
}
