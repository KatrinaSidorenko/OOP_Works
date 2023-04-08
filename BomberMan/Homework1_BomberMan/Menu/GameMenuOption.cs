﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_BomberMan
{
    public class GameMenuOption
    {
        public string OptionName { get; }
        public Action SelectedOption { get; }
        public GameMenuOption(string optionName, Action selectedOption)
        {
            OptionName = optionName;
            SelectedOption = selectedOption;
        }

    }
}
