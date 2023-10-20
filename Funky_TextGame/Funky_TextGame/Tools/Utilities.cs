using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame
{
    static class Utilities
    {
        public static void KeyEntry()
        {
            WriteLine("(Press any key to continue)");
            ReadKey(true);

        }

        public static void ExitConsole()
        {
            WriteLine("\n(Press any key to exit)");
            ReadKey(true);
            Environment.Exit(0);
        }
        public static async Task Delay(string Text)
        {
            foreach (char c in Text)
            {
                Console.Write(c);
                // delays each character for a more natural game feel
                await Task.Delay(50);
            }

            Thread.Sleep(700); // creates a delay before writing the next line
            Console.WriteLine(); // readies the next line
        }
    }

}
