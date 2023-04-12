using BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BomberMan
{
    public class Bomb : GameObject
    {
        public override char Character { get; set; } = Constant.BombChar;
        private Map _bombMap;
        private Thread _thread;
        private Player _player;
        public Bomb(Map map)
        {
            this.X = map.Player.X;
            this.Y = map.Player.Y;
            _player = map.Player;
            _bombMap = map;

            map[Y, X] = this; 
        }


        private void DeleteBombSurrounding()
        {
            ChangeGameCondition();

            new EmptySpace().SetObjectIntoMap( Y, X);
            new Coin().SetObjectIntoMap( Y, X);
        }

        public void CreateBlustWave()
        {
            Thread.Sleep(2000);
            new BlustWave().SetObjectIntoMap(Y, X);
            Thread.Sleep(1000);            
            DeleteBombSurrounding();
        }

        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.Write(Character);
        }

        private void ChangeGameCondition()
        {
            if (_player.X == X && _player.Y == Y
                || _player.X == X - 1 && _player.Y == Y
                || _player.X == X + 1 && _player.Y == Y
                || _player.X == X  && _player.Y == Y - 1
                || _player.X == X && _player.Y == Y + 1)
            {
                GameProperties.Condition = GameCondition.Dead;
            }
        }

        public override bool CanMove(int newY, int newX)
        {
            return false;
        }

        public override void Action(int y, int x)
        {
            _thread = new Thread(new ThreadStart(CreateBlustWave));
            _thread.Start();
        }

        public override bool CanBeDestroyed()
        {
            return true;
        }
    } 
}
