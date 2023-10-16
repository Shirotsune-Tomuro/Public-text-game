using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Funky_TextGame

{

    class Story

    {       
        static async Task Main()
        {
            // this will be how i print text with delay
            await TextTool.Delay("Welcome to FunkyText Game");
            await TextTool.Delay("What would you like to do?");
            Console .WriteLine();
            Console .WriteLine("Start Game");
            Console .WriteLine("End Game");
                        
            await TextTool.Continue();  
            Console.ReadKey();
            CombatSequence.CombatStart();
        }       

    }

}