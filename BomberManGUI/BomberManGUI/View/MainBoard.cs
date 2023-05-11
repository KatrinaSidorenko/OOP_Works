using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Bomberman;
using Bomberman.GameObjects;

namespace BomberManGUI
{
    public class MainBoard
    {
        public Panel GamePanel;
        public PictureBox[,] ImgMap;
        public Map PhisicMap;
        public static int BoxSize = 38;
        public PictureBox Player = new PictureBox();
        private int _sizeX = Constant.WindowXSize;
        private int _sizeY = Constant.WindowYSize;
        public MainBoard(Panel panel) 
        { 
            GamePanel = panel;

            InitStartGame();
        }

        private void InitStartGame()
        {
            ImgMap = new PictureBox[_sizeX, _sizeY];
            PhisicMap = new Map();

            GamePanel.Controls.Clear();

            //if (GamePanel.Width / _sizeX < GamePanel.Height / _sizeY)
            //{
            //    BoxSize = GamePanel.Width / _sizeX;
            //}
            //else
            //{
            //    BoxSize = GamePanel.Height / _sizeY;
            //}

            for (var x = 0; x < _sizeX; x++)
            {
                for(var y = 0; y < _sizeY; y++)
                {
                    PhisicMap[x, y].Draw(x, y, BoxSize, GamePanel, ImgMap);
                }
            }

            CreatePlayer();
        }

        private void CreatePlayer()
        {
            Player.Location = new Point(PhisicMap.PlayerXCoordiante*(BoxSize - 1), PhisicMap.PlayerYCoordiante*(BoxSize - 1));
            Player.Size = new Size(BoxSize, BoxSize);
            Player.SizeMode = PictureBoxSizeMode.StretchImage;

            GamePanel.Controls.Add(Player);
            Player.BringToFront();
            Player.Image = Properties.Resources.Bomber__2_;
        }
    }
}
