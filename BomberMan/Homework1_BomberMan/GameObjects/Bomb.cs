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

            base.SetObjectIntoMap(map, Y, X);

            _thread = new Thread(new ThreadStart(CreateBlustWave));
            _thread.Start();
        }


        private void DeleteBombSurrounding()
        {
            SetGameCondition(_bombMap);
            new EmptySpace().SetObjectIntoMap(_bombMap, Y, X);
            new Coin().SetObjectIntoMap(_bombMap, Y, X);
        }

        public void CreateBlustWave()
        {
            Thread.Sleep(2000);
            new BlustWave().SetObjectIntoMap(_bombMap, Y, X);
            Thread.Sleep(1000);            
            DeleteBombSurrounding();
        }

        public override void Draw(int y, int x)
        {
            Console.SetCursorPosition(x + 10, y + 5);
            Console.Write(Character);
        }

        public override void SetGameCondition(Map map)
        {
            if(map.Player.Y == this.Y &&  map.Player.X == this.X || map[map.Player.Y, map.Player.X].Character == Constant.BlustWaveChar)
            {
                Condition = GameCondition.Dead;
            }
            //if (map[map.Player.Y, map.Player.X].Character == Constant.BombChar || map[map.Player.Y, map.Player.X].Character == Constant.BlustWaveChar)
            //{
            //    Condition = GameCondition.Dead;
            //}
        }

    } 
}
