﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BomberManGUI.Enums;
using BomberManGUI.GameObjects;

namespace BomberManGUI.View
{
    public class SceneDrawer
    {
        public Panel _gamePanel;
        public PictureBox[,] _imgMap;
        public Map PhisicMap;
        public static int BoxSize = 38;
        public PictureBox _player = new PictureBox();
        private int _sizeX = Constant.WindowXSize;
        private int _sizeY = Constant.WindowYSize;
        public SceneDrawer(Panel panel) 
        { 
            _gamePanel = panel;

            DrawStartScene();
        }

        private void DrawStartScene()
        {
            _imgMap = new PictureBox[_sizeX, _sizeY];
            PhisicMap = new Map();

            _gamePanel.Controls.Clear();

            for (var x = 0; x < _sizeX; x++)
            {
                for(var y = 0; y < _sizeY; y++)
                {
                    PhisicMap[x, y].Draw(x, y, BoxSize, _gamePanel, _imgMap);
                }
            }

            CreatePlayer();
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

        public void DrawPlayerMove(Direction direction, int x, int y)
        {
            _imgMap[x, y].Image = Converter.ObjectTypeToPicture[typeof(EmptySpace)];
            var newCoordinates = Converter.DirectionToPointCoordinates[direction];
            _player.Location = new Point(_player.Location.X + newCoordinates.pointX, _player.Location.Y + newCoordinates.pointY);
            
        }
        public void DrawBomb(int x, int y)
        {
            _imgMap[x, y].Image = Converter.ObjectTypeToPicture[typeof(Bomb)];
        }

        public void BaseObjectsDrawer(List<(int, int)> coordinates, Type objType)
        {
            foreach (var coordinate in coordinates)
            {
                _imgMap[coordinate.Item1, coordinate.Item2].Image = Converter.ObjectTypeToPicture[objType]; ;
            }
        }

        public void DrawBlustWave(List<(int, int)> coordinates)
        {
            BaseObjectsDrawer(coordinates, typeof(BlustWave));           
        }

        public void DrawEmptySpaces(List<(int, int)> coordinates)
        {
            BaseObjectsDrawer(coordinates, typeof(EmptySpace));
        }
    }
}
