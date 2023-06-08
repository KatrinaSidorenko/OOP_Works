using BomberManGUI.Enums;
using BomberManGUI.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BomberManGUI.View
{
    public class SceneManager : BaseSceneManager
    {
        public override Map PhisicMap { get; set; }
        public static int BoxSize = 38;
        private Panel _gamePanel;
        private PictureBox[,] _imgMap;      
        private PictureBox _player = new PictureBox();
        private int _sizeX = Constant.WindowXSize;
        private int _sizeY = Constant.WindowYSize;
        public SceneManager(Panel panel) 
        { 
            _gamePanel = panel;

            DrawStartScene();
        }

        public override void DrawStartScene()
        {
            _imgMap = new PictureBox[_sizeX, _sizeY];
            PhisicMap = new Map();

            for (var x = 0; x < _sizeX; x++)
            {
                for(var y = 0; y < _sizeY; y++)
                {
                    PhisicMap[x, y].Draw(this, x, y);
                }
            }

            CreatePlayer();

            _gamePanel.Show();
        }

        private void CreatePlayer()
        {
            _player.Location = new Point(PhisicMap.PlayerXCoordiante*(BoxSize - 1), PhisicMap.PlayerYCoordiante*(BoxSize - 1));
            _player.Size = new Size(BoxSize, BoxSize);
            _player.SizeMode = PictureBoxSizeMode.StretchImage;

            _gamePanel.Controls.Add(_player);
            _player.BringToFront();
            _player.Image = Converter.ObjectTypeToPicture[typeof(Player)];
        }

        public override void DrawObject(Type type, int x, int y)
        {
            PictureBox picture = new PictureBox();
            picture.Location = new Point(x * (BoxSize - 1), y * (BoxSize - 1));
            picture.Size = new Size(BoxSize, BoxSize);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;

            _imgMap[x, y] = picture;
            _gamePanel.Controls.Add(picture);

            picture.Image = Converter.ObjectTypeToPicture[type];
        }
        public override void DrawPlayerMove(Direction direction, int x, int y)
        {
            _imgMap[x, y].Image = Converter.ObjectTypeToPicture[typeof(EmptySpace)];
            var newCoordinates = Converter.DirectionToPointCoordinates[direction];
            _player.Location = new Point(_player.Location.X + newCoordinates.pointX, _player.Location.Y + newCoordinates.pointY);
            
        }
        public override void DrawBomb(int x, int y)
        {
            _imgMap[x, y].Image = Converter.ObjectTypeToPicture[typeof(Bomb)];
        }

        public override void BaseObjectsDrawer(List<(int, int)> coordinates, Type objType)
        {
            foreach (var coordinate in coordinates)
            {
                _imgMap[coordinate.Item1, coordinate.Item2].Image = Converter.ObjectTypeToPicture[objType]; ;
            }
        }

        public override void DrawBlustWave(List<(int, int)> coordinates)
        {
            BaseObjectsDrawer(coordinates, typeof(BlustWave));           
        }

        public override void DrawEmptySpaces(List<(int, int)> coordinates)
        {
            BaseObjectsDrawer(coordinates, typeof(EmptySpace));
        }

        public override void PlayMusic()
        {
            MusicManager.BombSoundPlay();
        }
    }
}
