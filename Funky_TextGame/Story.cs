using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Funky_TextGame

{

    class Story

    {

        static async Task Main()
           

        {
            // this will determine whether or not the game should be playing
            bool IsPlaying = true;
            
            // this will be how i print text with delay
            await TextDelay.Print("hey there traveller");
            await TextDelay.Print("You look kinda cold there, need a hand?");
            Console.WriteLine();
            Console.WriteLine("Press <Enter> to continue");

            //this checks for a user key input
            ConsoleKeyInfo keyInfo = Console.ReadKey();
          

            while (IsPlaying) 
                { 

                    if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    await TextDelay.Print("Let's get started then");
                    Console.Clear();
                    CombatSequence.CombatStart();
                    break;
                }
                else
                {
                    await TextDelay.Print("do you wish to stop?");
                    Console.WriteLine("Y/N");
                    ConsoleKeyInfo Continue = Console.ReadKey();

                    if (Continue.Key == ConsoleKey.Y)
                    {
                        // terminates the game
                        await TextDelay.Print("See you next time then Traveller");
                        Thread.Sleep(1000);
                        IsPlaying = false;
                    }
                  
                }

            }

        }

    }

}