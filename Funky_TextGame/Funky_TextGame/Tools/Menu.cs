using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame
{
    internal class Menu
    {
        private int selectedIndex;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            selectedIndex = 0;
        }
        //makes it so this data can't be edited outside of this blueprint
        private void DisplayOptions()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == selectedIndex)
                {
                    //when an item is selectes, change the background colour and give it a prefix
                    prefix = ">";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";                    
                    ResetColor();
                }
                //writes each menu on a new line alongside its defined prefix
                WriteLine($"{prefix} [ {currentOption} ]");
            }
            ResetColor();
        }

        //the entry point that other blueprints will use to call this function
        public int Run()
        {
            //funny nested bools in a while loop
            ConsoleKey Key;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Key = keyInfo.Key;

                if (Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = Options.Length - 1;
                    }

                }
                else if (Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == Options.Length)
                    {
                        selectedIndex = 0;
                    }

                }

            } while (Key != ConsoleKey.Enter);
            //returns an index value to wherever called the function
            return selectedIndex;
        }
    }
}
