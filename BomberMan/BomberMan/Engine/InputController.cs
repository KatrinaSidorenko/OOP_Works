using Bomberman.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    public class InputController
    {
        private Dictionary<ConsoleKey, PlayerAction> _inputConverter;
        public InputController() 
        {
            _inputConverter = new Dictionary<ConsoleKey, PlayerAction>()
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

            if (_inputConverter.ContainsKey(ki.Key))
            {
                return _inputConverter[ki.Key];
            }
            
            return PlayerAction.None;
        }
    }
}
