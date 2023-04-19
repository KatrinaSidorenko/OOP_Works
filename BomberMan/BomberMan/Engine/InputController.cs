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
        //private GameLogic _gameLogic = new GameLogic();
        public PlayerAction GetInput()
        {
            ConsoleKeyInfo ki = Console.ReadKey(true);

            switch (ki.Key)
            {
                case ConsoleKey.Escape:
                    return PlayerAction.End;                 
                case ConsoleKey.Spacebar:
                    return PlayerAction.Bomb;
                case ConsoleKey.LeftArrow:
                    return PlayerAction.Left;
                case ConsoleKey.RightArrow:
                    return PlayerAction.Right;
                case ConsoleKey.UpArrow:
                    return PlayerAction.Up;
                case ConsoleKey.DownArrow:
                    return PlayerAction.Down;
            }

            return PlayerAction.None;
        }
    }
}
