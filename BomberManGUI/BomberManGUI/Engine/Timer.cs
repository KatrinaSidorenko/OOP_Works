using Bomberman.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class Timer
    {
        private DateTime _startTime;
        private GameLogic _logic;
        private TimeSpan _duration = new TimeSpan(0, 2, 0);
        public Timer(GameLogic _gameLogic)
        {
            _logic = _gameLogic;
            _startTime = DateTime.Now;
        }

        public void GemaOverTimeCheck()
        {
            if (DateTime.Now.Subtract(_startTime) > _duration && _logic.Walls == 0
                || DateTime.Now.Subtract(_startTime) < _duration && _logic.Walls == 0)
            {
                _logic.Condition = GameCondition.Victory;
            }
            else if (DateTime.Now.Subtract(_startTime) > _duration)
            {
                _logic.Condition = GameCondition.TimeLeftEnd;
            }
        }

        public TimeSpan GetRestOfTheTime()
        {
            if(_logic.Condition == GameCondition.TimeLeftEnd || _logic.Condition == GameCondition.Dead)
            {
                return TimeSpan.Zero;
            }

            return _duration - (DateTime.Now.Subtract(_startTime));
        }
    }
   }
