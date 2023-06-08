﻿using BomberManGUI.GameObjects;
using BomberManGUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomberManGUI.Engine
{
    // Відповідає за отримання введених користувачем даних та їх конвертування у відповідне перелічення PleayerAction 
    public class InputController 
    {
        private Dictionary<Keys, PlayerAction> _inputConverter;
        public InputController()
        {
            _inputConverter = new Dictionary<Keys, PlayerAction>()
            {
                {Keys.Escape,  PlayerAction.End},
                {Keys.Space, PlayerAction.Bomb},
                {Keys.Left, PlayerAction.Left},
                {Keys.Right, PlayerAction.Right},
                {Keys.Up, PlayerAction.Up},
                {Keys.Down, PlayerAction.Down},
            };
        }
        public PlayerAction GetInput(Keys ki)
        {
            if (_inputConverter.ContainsKey(ki))
            {
                return _inputConverter[ki];
            }
            
            return PlayerAction.None;
        }

    }
}
