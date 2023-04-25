using Bomberman.GameObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bomberman
{
    public class GameLogic
    {
        public readonly Map MainMap;
        public int PlayerXCoordinate;
        public int PlayerYCoordinate;
        public GameCondition Condition = GameCondition.InProgress;
        public int Score;
        public int Walls;
        public Timer Timer;
        private Queue<(int, int)> _bombCoordinates = new Queue<(int, int)>();
        private Thread _thread;
        private InputController _inputController = new InputController();
        private GameOver _gameOver = new GameOver();
        private GamePhisics _gamePhisics;

        public GameLogic() 
        {
            MainMap = new Map();
            Walls = MainMap.TotalAmountOfTempWalls;
            Timer = new Timer(this);
            _gamePhisics = new GamePhisics(MainMap);
            PlayerXCoordinate = MainMap.PlayerXCoordiante;
            PlayerYCoordinate = MainMap.PlayerYCoordiante;
        }
        public void ProcessGameLogic()
        {
            var input = _inputController.GetInput();
            Timer.GemaOverTimeCheck();
            _gameOver.CheckGameOver(Condition);

            Dictionary<PlayerAction, Action> actionCollection = new Dictionary<PlayerAction, Action>()
            {
                { PlayerAction.Up, MoveUpRequire },
                { PlayerAction.Down, MoveDownRequire },
                { PlayerAction.Left, MoveLeftRequire },
                { PlayerAction.Right, MoveRightRequire },
                { PlayerAction.Bomb, BombCreationRequire },
                { PlayerAction.End, CloseWindowRequire }
            };

            if (input != PlayerAction.None)
            {
                actionCollection[input].Invoke();
            }
                    
        }
        private void CloseWindowRequire()
        {
            Environment.Exit(0);
        }

        private bool BaseMovingRequire(int newY, int newX) //gets temp values of coordinates
        {
            if (MainMap[newY, newX].CanMoveThrough)
            {
                MainMap[newY, newX].Action(this);
                return true;
            }

            return false;
        }
        private void MoveLeftRequire()
        {
            if (BaseMovingRequire(PlayerYCoordinate , PlayerXCoordinate - 1))
            {
                _gamePhisics.PlayerLeftMove(PlayerYCoordinate, PlayerXCoordinate);
                PlayerXCoordinate -= 1;
            }
        }

        private void MoveRightRequire()
        {
            if (BaseMovingRequire(PlayerYCoordinate, PlayerXCoordinate + 1))
            {
                _gamePhisics.PlayerRightMove(PlayerYCoordinate, PlayerXCoordinate);
                PlayerXCoordinate += 1;
            }
        }

        private void MoveUpRequire()
        {
            if(BaseMovingRequire(PlayerYCoordinate - 1, PlayerXCoordinate))
            {
                _gamePhisics.PlayerUpMove(PlayerYCoordinate, PlayerXCoordinate);
                PlayerYCoordinate -= 1;
            }
        }

        private void MoveDownRequire()
        {
            if (BaseMovingRequire(PlayerYCoordinate + 1, PlayerXCoordinate))
            {
                _gamePhisics.PlayerDownMove(PlayerYCoordinate, PlayerXCoordinate);
                PlayerYCoordinate += 1;
            }
        }

        private void BombCreationRequire()
        {
            _thread = new Thread(new ThreadStart(CreateBlustWaveRequire));

            int tempX = PlayerXCoordinate;
            int tempY = PlayerYCoordinate;

            List<Action> movingsList = new List<Action>() { MoveUpRequire , MoveDownRequire, MoveLeftRequire, MoveRightRequire };
            foreach (Action moving in movingsList)
            {
                if(PlayerXCoordinate ==  tempX && PlayerYCoordinate == tempY)
                {
                    moving.Invoke();
                }
                else
                {
                    break;
                }               
            }

            _gamePhisics.CreateBomb(tempY, tempX);
            _bombCoordinates.Enqueue((tempY, tempX));
            
            _thread.Start();           
        }

        private void CreateBlustWaveRequire()
        {
            Thread.Sleep(2000);

            if(!(_bombCoordinates.Count() == 0))
            {
                var coordinates = CheckBombSurrounding(_bombCoordinates.Peek().Item1, _bombCoordinates.Peek().Item2);
                coordinates.Add(_bombCoordinates.Dequeue());
                _gamePhisics.CreateBlustWave(coordinates);
                Thread.Sleep(1000);
                _gamePhisics.ClearBombSurrounding(coordinates);
            }
        }

        private List<(int, int)> CheckBombSurrounding(int y, int x)
        {
            List<(int, int)> coordinatesForDestroy = new List<(int, int)> ();
            List<(int, int)> nodes = new List<(int, int)>() { (y - 1, x), (y + 1, x), (y, x + 1), (y, x - 1) };

            foreach (var coordianate in nodes)
            {
                var element = MainMap[coordianate.Item1, coordianate.Item2];
                element.Action(this);

                if(element.CanBeDestroyed)
                {
                    if(element is TempWall temWall)
                    {
                        if(temWall.Strengh == 0)
                        {
                            coordinatesForDestroy.Add(coordianate);
                        }
                    }
                    else
                    {
                        coordinatesForDestroy.Add(coordianate);
                    }
                    
                }
            }

            return coordinatesForDestroy;
        }
    }
}
