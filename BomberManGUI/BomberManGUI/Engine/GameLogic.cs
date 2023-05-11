using Bomberman.GameObjects;
using BomberManGUI;
using BomberManGUI.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Thread _bombThread;
        private GameMovements _movementsUI;
        private GamePhisics _gamePhisics;

        public GameLogic(MainBoard board, PictureBox[,] box, Map map) 
        {
            MainMap = map;
            Walls = MainMap.TotalAmountOfTempWalls;
            Timer = new Timer(this);
            _gamePhisics = new GamePhisics(MainMap);
            _movementsUI = new GameMovements(box, board.Player);
            PlayerXCoordinate = MainMap.PlayerXCoordiante;
            PlayerYCoordinate = MainMap.PlayerYCoordiante;
        }
        public void ProcessGameLogic(PlayerAction input)
        {
            Timer.GemaOverTimeCheck();

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

        private bool BaseMovingRequire(int newX, int newY) //gets temp values of coordinates
        {
            if (MainMap[newX, newY].CanMoveThrough)
            {
                MainMap[newX, newY].Action(this, _movementsUI, newX, newY);

                return true;
            }

            return false;
        }
        private void MoveLeftRequire()
        {
            if (BaseMovingRequire(PlayerXCoordinate - 1, PlayerYCoordinate))
            {
                _movementsUI.PlayerMove(PlayerAction.Left);
                _gamePhisics.PlayerLeftMove(PlayerXCoordinate, PlayerYCoordinate);
                PlayerXCoordinate -= 1;
            }
        }

        private void MoveRightRequire()
        {
            if (BaseMovingRequire(PlayerXCoordinate + 1, PlayerYCoordinate))
            {
                _movementsUI.PlayerMove(PlayerAction.Right);
                _gamePhisics.PlayerRightMove(PlayerXCoordinate, PlayerYCoordinate);
                PlayerXCoordinate += 1;
            }
        }

        private void MoveUpRequire()
        {
            if(BaseMovingRequire(PlayerXCoordinate, PlayerYCoordinate - 1))
            {
                _movementsUI.PlayerMove(PlayerAction.Up);
                _gamePhisics.PlayerUpMove(PlayerXCoordinate, PlayerYCoordinate);
                PlayerYCoordinate -= 1;
            }
        }

        private void MoveDownRequire()
        {
            if (BaseMovingRequire(PlayerXCoordinate, PlayerYCoordinate + 1))
            {

                _gamePhisics.PlayerDownMove(PlayerXCoordinate, PlayerYCoordinate);
                _movementsUI.PlayerMove(PlayerAction.Down);
                PlayerYCoordinate += 1;
                
            }
        }

        private void BombCreationRequire()
        {
            _bombThread = new Thread(new ThreadStart(CreateBlustWaveRequire));

            int tempX = PlayerXCoordinate;
            int tempY = PlayerYCoordinate;

            List<Action> movingsList = new List<Action>() { MoveUpRequire, MoveDownRequire, MoveLeftRequire, MoveRightRequire };
            foreach (Action moving in movingsList)
            {
                if (PlayerXCoordinate == tempX && PlayerYCoordinate == tempY)
                {
                    moving.Invoke();
                }
                else
                {
                    break;
                }
            }

            _gamePhisics.CreateBomb(tempX, tempY);
            _movementsUI.BombCreation(tempX, tempY);

            _bombCoordinates.Enqueue((tempX, tempY));

            _bombThread.Start();           
        }

        private void CreateBlustWaveRequire()
        {
            Thread.Sleep(2000);
            MusicManager.BombSoundPlay();

            if (!(_bombCoordinates.Count() == 0))
            {
                var coordinates = CheckBombSurrounding(_bombCoordinates.Peek().Item1, _bombCoordinates.Peek().Item2);
                coordinates.Add(_bombCoordinates.Dequeue());
                
                _gamePhisics.CreateBlustWave(coordinates);
                _movementsUI.BlustWaveCreation(coordinates);

                Thread.Sleep(1000);

                _gamePhisics.ClearBombSurrounding(coordinates);
                _movementsUI.ClearBombSurrounding(coordinates);
            }
        }

        private List<(int, int)> CheckBombSurrounding(int x, int y)
        {
            List<(int, int)> coordinatesForDestroy = new List<(int, int)> ();
            List<(int, int)> nodes = new List<(int, int)>() { (x - 1, y), (x + 1, y), (x, y + 1), (x, y - 1) };

            foreach (var coordianate in nodes)
            {
                var element = MainMap[coordianate.Item1, coordianate.Item2];
                element.Action(this, _movementsUI, coordianate.Item1, coordianate.Item2);

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
