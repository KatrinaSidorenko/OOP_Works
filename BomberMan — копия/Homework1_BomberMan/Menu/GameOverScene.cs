﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public static class GameOverScene
    {
        public static void GameOverSceneRender()
        {
            Console.Clear();
            Console.Write(@"
 .d8888b.                                        .d88888b.                            
d88P  Y88b                                      d88P"" ""Y88b                           
888    888                                      888     888                           
888         8888b.  88888b.d88b.   .d88b.       888     888 888  888  .d88b.  888d888 
888  88888     ""88b 888 ""888 ""88b d8P  Y8b      888     888 888  888 d8P  Y8b 888P""   
888    888 .d888888 888  888  888 88888888      888     888 Y88  88P 88888888 888     
Y88b  d88P 888  888 888  888  888 Y8b.          Y88b. .d88P  Y8bd8P  Y8b.     888     
 ""Y8888P88 ""Y888888 888  888  888  ""Y8888        ""Y88888P""    Y88P    ""Y8888  888     
                                                                                      
                                                                                      
                                                                                      
");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

