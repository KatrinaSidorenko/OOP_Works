﻿using BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class ScreneRender
    {
        private Map _gameMap;
        private KeyboardController _keyController;
        private Timer _timer;
        public ScreneRender(char playerChar)
        {
            _gameMap = new Map();
            _gameMap.Player.SetGameCondition(_gameMap);
            _gameMap.Player.Character = playerChar;
            _keyController = new KeyboardController(_gameMap);
            _timer = new Timer();

        }

        public void GameProcessRun()
        {
            Console.CursorVisible = false;
            Console.Clear();

            while (true)
            {
                _gameMap.PrintMap();
                _keyController.KeyboardReading();
                PrintCurrentPlayerData();
                _timer.GemaOverTimeCheck();
            }                
        }

        public void PrintCurrentPlayerData()
        {
            Console.SetCursorPosition(45, 5);
            Console.Write($"Player Score: {_gameMap.Player.Score}");
            Console.SetCursorPosition(45, 7);
            Console.Write($"Time left: {_timer.GetRestOfTheTime().Seconds}");        
        }
    }
}
