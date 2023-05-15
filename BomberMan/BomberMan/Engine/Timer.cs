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

        public void CheckGameOverTime()
        {
            if (DateTime.Now.Subtract(_startTime) > _duration && _logic.Walls == 0
                || DateTime.Now.Subtract(_startTime) < _duration && _logic.Walls == 0)
            {
                _logic.GameState = GameState.Victory;
            }
            else if (DateTime.Now.Subtract(_startTime) > _duration)
            {
                _logic.GameState = GameState.TimeLeftEnd;
            }
        }

        public TimeSpan GetRestOfTheTime()
        {
            return _duration - (DateTime.Now.Subtract(_startTime));
        }
    }
 }
