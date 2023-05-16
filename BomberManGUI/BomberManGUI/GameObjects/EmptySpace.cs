﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomberManGUI.Enums;
using System.Windows.Forms;
using BomberManGUI.View;

namespace BomberManGUI.GameObjects
{
    public class EmptySpace : GameObject
    {

        public override bool CanMoveThrough => true;

        public override bool CanBeDestroyed => true;

        public override void Draw(int x, int y, int boxSize, Panel gamePanel, PictureBox[,] mapPics)
        {
            PictureBoxCreation(x, y, boxSize, gamePanel, mapPics).Image = Converter.ObjectTypeToPicture[typeof(EmptySpace)];
        }
    }
}
