﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract char Character { get; set; }
    }
}
