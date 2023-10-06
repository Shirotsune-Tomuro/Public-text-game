using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funky_TextGame
{
    public class TextDelay
    {

    public static async Task Print(string Text)
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

