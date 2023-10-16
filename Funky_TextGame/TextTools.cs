using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funky_TextGame
{
    public class TextTool
    {

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

        public static async Task Continue()
        {
            //this checks for a user key input
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Press <Enter> to continue");
                keyInfo = Console.ReadKey();


                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    Console.Clear();
                    await Delay("That was the wrong key");
                }

            } while (keyInfo.Key != ConsoleKey.Enter);

        }
    }

}

