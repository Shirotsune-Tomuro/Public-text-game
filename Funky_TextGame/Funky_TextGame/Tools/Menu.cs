using Funky_TextGame.StartFunctions;
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
        protected Game myGame;
    
        private int selectedIndex;
        private string[] Options;
        private string Prompt;
        private string Prompt2;

       
        public Menu(string prompt, string[] options, string prompt2, Game Game)
        {            
            myGame = Game;
            Prompt = prompt;
            Prompt2 = prompt2;
            Options = options;
            selectedIndex = 0;
        }
        //makes it so this data can't be edited outside of this blueprint
        private void DisplayOptions()
        {            
            WriteLine(Prompt);
            WriteLine("-----------------------------------");
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
                CursorLeft += 10;
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
                WriteLine("-----------------------------------");
                WriteLine("\n");
                WriteLine(Prompt2);

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
                else if (Key == ConsoleKey.Home)
                {
                    myGame.MyModTools.CmdLine();
                }

            } while (Key != ConsoleKey.Enter);
            //returns an index value to wherever called the function

            return selectedIndex;
        }
        
    }
}
