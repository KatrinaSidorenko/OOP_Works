using BomberManGUI.GameObjects;
using BomberManGUI.GameObjects.Walls;
using BomberManGUI.Enums;
using System;
using BomberManGUI.View;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BomberManGUI.Helpers;

namespace BomberManGUI.Engine
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
        private BaseSceneManager _sceneController;
        private GamePhisics _gamePhisics;
        private Dictionary<PlayerAction, Func<bool>> _actionCollection;

        public GameLogic(BaseSceneManager board)
        {
            MainMap = board.PhisicMap;
            Walls = MainMap.TotalAmountOfTempWalls;
            Timer = new Timer(this);
            _gamePhisics = new GamePhisics(MainMap);
            _sceneController = board;
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

            if (input != PlayerAction.None)
            {
                if (_actionCollection.ContainsKey(input))
                {
                    return _actionCollection[input]();
                }
                else
                {
                    PlayerMoveRequest(BaseConverter.ActionToDirection[input]);
                }
            }

            return GameState == GameState.InProgress;
        }

        private void PlayerMoveRequest(Direction direction)
        {
            int newY = _playerYCoordinate + BaseConverter.DirectionToCoordinates[direction].dy;
            int newX = _playerXCoordinate + BaseConverter.DirectionToCoordinates[direction].dx;
            GameObject currentObject = MainMap[newX, newY];

            if (currentObject.CanMoveThrough)
            {
                currentObject.Action(this);
                _sceneController.DrawPlayerMove(direction, _playerXCoordinate, _playerYCoordinate);
                _gamePhisics.PlayerPhisicMove((_playerXCoordinate, _playerYCoordinate), (newX, newY));

                _playerYCoordinate = newY;
                _playerXCoordinate = newX;
            }
        }
        private bool CloseWindowRequest()
        {
            GameState = GameState.Exit;
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
                if (_playerXCoordinate == tempX && _playerYCoordinate == tempY)
                {
                    PlayerMoveRequest(moving);
                }
                else
                {
                    break;
                }
            }

            _gamePhisics.CreateBomb(tempX, tempY);
            _sceneController.DrawBomb(tempX, tempY);

            _bombCoordinates.Enqueue((tempX, tempY));

            _bombThread.Start();

            return true;
        }

        private void CreateBlustWaveRequest()
        {
            Thread.Sleep(2000);
            _sceneController.PlayMusic();

            if (!(_bombCoordinates.Count() == 0))
            {
                var coordinates = CheckBombSurrounding(_bombCoordinates.Peek().Item1, _bombCoordinates.Peek().Item2);
                coordinates.Add(_bombCoordinates.Dequeue());

                _gamePhisics.CreateBlustWave(coordinates);
                _sceneController.DrawBlustWave(coordinates);

                Thread.Sleep(1000);

                _gamePhisics.ClearBombSurrounding(coordinates);
                _sceneController.DrawEmptySpaces(coordinates);
            }
        }

        private List<(int, int)> CheckBombSurrounding(int x, int y)
        {
            List<(int, int)> coordinatesForDestroy = new List<(int, int)>();
            List<(int, int)> nodes = new List<(int, int)>() { (x - 1, y), (x + 1, y), (x, y + 1), (x, y - 1) };

            foreach (var coordianate in nodes)
            {
                var element = MainMap[coordianate.Item1, coordianate.Item2];
                element.Action(this);

                if (element.CanBeDestroyed)
                {
                    if (element is TempWall temWall)
                    {
                        if (temWall.Strengh == 0)
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
