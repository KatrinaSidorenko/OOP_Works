using BomberManGUI.GameObjects;
using System;
using BomberManGUI.Enums;

namespace BomberManGUI.Engine
{
    public class Timer
    {
        private DateTime _startTime;
        private GameLogic _logic;
        private TimeSpan _gameDuration = new TimeSpan(0, 2, 0);
        public Timer(GameLogic _gameLogic)
        {
            _logic = _gameLogic;
            _startTime = DateTime.Now;
        }

        public void CheckGameOverTime()
        {
            if (DateTime.Now.Subtract(_startTime) > _gameDuration && _logic.Walls == 0
                || DateTime.Now.Subtract(_startTime) < _gameDuration && _logic.Walls == 0)
            {
                _logic.GameState = GameState.Victory;
            }
            else if (DateTime.Now.Subtract(_startTime) > _gameDuration)
            {
                _logic.GameState = GameState.TimeLeftEnd;
            }
        }

        public TimeSpan GetRestOfTheTime()
        {
            if (_logic.GameState == GameState.TimeLeftEnd || _logic.GameState == GameState.Dead)
            {
                return TimeSpan.Zero;
            }

            return _gameDuration - (DateTime.Now.Subtract(_startTime));
        }
    }
   }
