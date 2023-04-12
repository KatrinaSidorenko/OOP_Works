﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BomberMan
{
    public static class Animations
    {
        public static void SimpleAnimation(string text, int delay)
        {            
            for(int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(delay);
            }
        }

        public static void RandomColorAnimation(string text, int delay)
        {
            var random = new Random();
            for (int i = 0; i < text.Length; i++)
            {
                var colors = Enum.GetValues(typeof(ConsoleColor));
                Console.ForegroundColor = (ConsoleColor) colors.GetValue(random.Next(colors.Length));
                Console.Write(text[i]);
                Thread.Sleep(delay);
            }
        }
    }
}
