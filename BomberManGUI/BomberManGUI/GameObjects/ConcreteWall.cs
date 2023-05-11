﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman.GameObjects
{
    public class ConcreteWall : GameObject
    {

        public override bool CanMoveThrough => false;

        public override bool CanBeDestroyed => false;

        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {          
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = BomberManGUI.Properties.Resources.concreteWall;
        }
    }
}
