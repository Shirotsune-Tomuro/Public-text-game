using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funky_TextGame.Funky_TextGame.Tools;
using Funky_TextGame.StartFunctions;
using static System.Console;

namespace Funky_TextGame.StartFunctions
{
    class Program
    {
        static void Main()
        {
            //sets title name
            Title = "Funky Text Game";
            // sets the cursor to be invisible
            CursorVisible = false;
            try
            {
                SetWindowSize(125,40);            
            }
            catch
            {
                WriteLine("Insufficient space for window");
                WriteLine("Try to adjust window settings and try again\n");
                Utilities.KeyEntry();
            }

            // creates an instance of the game class and stores it in a variable
            Game myGame = new Game();
            myGame.Start();
        }
    }
}
