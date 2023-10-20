using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//namespace Funky_TextGame

//{

//    class Program

//    {
//        public static Area CurrentArea = default!;

//        static async Task Main()
//        {
//            AreaInstance();

//            Thread Navigation = new Thread(DisplayArea);
//            Thread Narrative = new Thread(Story);

//            Navigation.Start();           
//            Narrative.Start();
//            Navigation.Join();
//            Narrative.Join();               
//        }
//        private static async void Story() 
//        {
//        // this will be how i print text with delay
//            Console.SetCursorPosition(0, 3);
//            await TextTool.Delay("Welcome to FunkyText Game");
//            await TextTool.Delay("What would you like to do?");
//            Console.WriteLine();
//            Console.WriteLine("Start Game");
//            Console.WriteLine("End Game");
//            await TextTool.Continue();
//            await TextTool.Delay("huzzah");
//            Console.ReadKey();
//        }
        

//        public static void AreaInstance()
//        {
//            Area Cave1 = new Area();
//            Area Cave2 = new Area();
//            Area Cave3 = new Area();
//            {
//                Cave1.Name = "Cave Zone 1";
//                Cave1.Description = "A cold dark place";
//                Cave1.Exits["north"] = Cave2;

//                Cave2.Name = "Cave zone 2";
//                Cave2.Description = "A cold dark place";
//                Cave2.Exits["North"] = Cave3;
//                Cave2.Exits["South"] = Cave1;

//                Cave3.Name = "Cave zone 3";
//                Cave3.Description = "A cold dark place";
//                Cave3.Exits["South"] = Cave2;

//                CurrentArea = Cave1;

//            }
            
           
//        }
//       static void DisplayArea() 
//       {
//            while (true)
//            {
//                Console.SetCursorPosition(0, 0);
//                // Display room information
//                Console.WriteLine(CurrentArea.Name);
//                Console.WriteLine(CurrentArea.Description);

//                // Handle player input and room transitions
//                string input = Console.ReadLine();
//                if (CurrentArea.Exits.ContainsKey(input))
//                {
//                    CurrentArea = CurrentArea.Exits[input];
//                }
//                else
//                {
//                    Console.WriteLine("You can't go that way.");
//                }

//            }
//       }
//    }

//}