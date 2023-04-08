﻿using Homework1_BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class KeyboardController
    {
        private Map _currentMap;
        private Player _player;
        public KeyboardController(Map map) 
        {
            _currentMap = map;
            _player = map.Player;
        }
        public void KeyboardReading()
        {
            if(GameObject.Condition == GameCondition.Victory)
            {
                GameOver.VictoryGameOver();
            }
            if(GameObject.Condition == GameCondition.TimeLeftEnd)
            {
                GameOver.GameOverTimeScene();
            }
            if (GameObject.Condition == GameCondition.Dead)
            {
                GameOver.DeadGameOver();
            }

            int tempX = _player.X;
            int tempY = _player.Y;

            ConsoleKeyInfo ki = Console.ReadKey(true);

            switch (ki.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Spacebar:
                    new Bomb(_currentMap);
                    break;
                case ConsoleKey.LeftArrow:
                    tempX--;
                    break;
                case ConsoleKey.RightArrow:
                    tempX++;
                    break;
                case ConsoleKey.UpArrow:
                    tempY--;
                    break;
                case ConsoleKey.DownArrow:
                    tempY++;
                    break;

            }

            _player.PlayerState(tempX, tempY, _currentMap);
        }
    }
}
