using BomberManGUI.Engine;
using BomberManGUI.Enums;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan
{
    public class ConsoleInpuControler
    {
        private Dictionary<ConsoleKey, PlayerAction> _inputConsoleConverter;
        public ConsoleInpuControler()
        {
            _inputConsoleConverter = new Dictionary<ConsoleKey, PlayerAction>()
            {
                {ConsoleKey.Escape,  PlayerAction.End},
                {ConsoleKey.Spacebar, PlayerAction.Bomb},
                {ConsoleKey.LeftArrow, PlayerAction.Left},
                {ConsoleKey.RightArrow, PlayerAction.Right},
                {ConsoleKey.UpArrow, PlayerAction.Up},
                {ConsoleKey.DownArrow, PlayerAction.Down},
            };
        }

        public PlayerAction GetInput()
        {
            ConsoleKeyInfo ki = Console.ReadKey(true);

            if (_inputConsoleConverter.ContainsKey(ki.Key))
            {
                return _inputConsoleConverter[ki.Key];
            }

            return PlayerAction.None;
        }
    }
}
