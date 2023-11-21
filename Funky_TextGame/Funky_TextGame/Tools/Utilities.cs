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
            Thread.Sleep (1000);
            WriteLine("\n\n(Press any key to continue)\n");
            ReadKey(true);

        }

        public static void ExitConsole()
        {
            WriteLine("\n(Press any key to exit)\n");
            ReadKey(true);
            Environment.Exit(0);
        }
        public static void Delay(string Text)
        {
            foreach (char c in Text)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }            
        }

    }

}
