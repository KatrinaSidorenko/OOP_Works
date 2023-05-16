using Bomberman.Enums;
using Bomberman.GameObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bomberman
{
    public class GameLogic
    {
        public readonly Map MainMap;        
        public GameState GameState = GameState.InProgress;
        public int Score;
        public int Walls;
        public Timer Timer;
        private int _playerXCoordinate;
        private int _playerYCoordinate;
        private Queue<(int, int)> _bombCoordinates = new Queue<(int, int)>();
        private Thread _bombThread;
        private GameOver _gameOver = new GameOver();
        private GamePhisics _gamePhisics;
        private Dictionary<PlayerAction, Func<bool>> _actionCollection;


        public GameLogic() 
        {
            MainMap = new Map();
            Walls = MainMap.TotalAmountOfTempWalls;
            Timer = new Timer(this);
            _gamePhisics = new GamePhisics(MainMap);
            _playerXCoordinate = MainMap.PlayerXCoordiante;
            _playerYCoordinate = MainMap.PlayerYCoordiante;
            _actionCollection = new Dictionary<PlayerAction, Func<bool>>()
            {
                {PlayerAction.Bomb, BombCreationRequest },
                {PlayerAction.End, CloseWindowRequest }
            };
        }
        public bool ProcessGameLogic(PlayerAction input)
        {
            Timer.CheckGameOverTime();
            _gameOver.CheckGameOver(GameState);
        
            if (input != PlayerAction.None)
            {
                if(_actionCollection.ContainsKey(input))
                {
                    return _actionCollection[input]();
                }
                else
                {
                    PlayerMoveRequest(Converter.ActionToDirection[input]);
                }
            }

            return GameState == GameState.InProgress;
        }

        private void PlayerMoveRequest(Direction direction)
        {
            int newY = _playerYCoordinate + Converter.DirectionToCoordinates[direction].dy;
            int newX = _playerXCoordinate + Converter.DirectionToCoordinates[direction].dx;

            if (MainMap[newY, newX].CanMoveThrough)
            {
                MainMap[newY, newX].Action(this);
                _gamePhisics.PlayerPhisicMove((_playerYCoordinate, _playerXCoordinate), (newY, newX));
                _playerYCoordinate = newY;
                _playerXCoordinate = newX;
            }
        }
        private bool CloseWindowRequest()
        {
            return false;
        }       

        private bool BombCreationRequest()
        {
            _bombThread = new Thread(new ThreadStart(CreateBlustWaveRequest));

            int tempX = _playerXCoordinate;
            int tempY = _playerYCoordinate;
            var movingsList = Enum.GetValues(typeof(Direction));
            
            foreach (Direction moving in movingsList)
            {
                if(_playerXCoordinate ==  tempX && _playerYCoordinate == tempY)
                {
                    PlayerMoveRequest(moving);
                }
                else
                {
                    break;
                }               
            }

            _gamePhisics.CreateBomb(tempY, tempX);
            _bombCoordinates.Enqueue((tempY, tempX));
            
            _bombThread.Start();

            return true;
        }

        private void CreateBlustWaveRequest()
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
            List<(int, int)> coordinatesThatCanBeDestroed = new List<(int, int)> ();
            List<(int, int)> coordinatesOfBombSurrounding = new List<(int, int)>() { (y - 1, x), (y + 1, x), (y, x + 1), (y, x - 1) };

            foreach (var coordianate in coordinatesOfBombSurrounding)
            {
                var element = MainMap[coordianate.Item1, coordianate.Item2];
                element.Action(this);

                if(element.CanBeDestroyed)
                {
                    if(element is TempWall temWall)
                    {
                        if(temWall.Strength == 0)
                        {
                            coordinatesThatCanBeDestroed.Add(coordianate);
                        }
                    }
                    else
                    {
                        coordinatesThatCanBeDestroed.Add(coordianate);
                    }
                    
                }
            }

            return coordinatesThatCanBeDestroed;
        }
    }
}
