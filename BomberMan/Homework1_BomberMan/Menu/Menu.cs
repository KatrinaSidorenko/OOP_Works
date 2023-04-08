using Homework1_BomberMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan.Menu
{
    public class Menu
    {
        public virtual void DrawMenu(List<GameMenuOption> options, GameMenuOption selectedOption)
        {            

            foreach (var option in options)
            {
                if (option == selectedOption)
                    Console.Write("--> ");
                else
                    Console.Write("   ");

                Console.WriteLine(option.OptionName + "  ");
            }
        }

        public virtual void HandleOptions(List<GameMenuOption> options, int index)
        {
            ConsoleKeyInfo ki;
            do
            {
                ki = Console.ReadKey(true);
                if (ki.Key == ConsoleKey.DownArrow && index + 1 < options.Count)
                    index++;

                if (ki.Key == ConsoleKey.UpArrow && index - 1 >= 0)
                    index--;

                DrawMenu(options, options[index]);

                if (ki.Key == ConsoleKey.Enter)
                {
                    options[index].SelectedOption.Invoke();
                    break;
                }
            } while (ki.Key != ConsoleKey.Escape);
        }
        
    }
}
