using Funky_TextGame.StartFunctions;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using static System.Console;


namespace Funky_TextGame.Funky_TextGame.Tools
{
    class ModTools
    {
        protected Game myGame;

        ConsoleKeyInfo keyInfo;
        bool CmdActive = false;
        public ModTools(Game Game)
        {
            myGame = Game;
            Task.Run(HandleInput);
        }

        void CmdLine()
        {            
            while (CmdActive == true)
            {
                CursorVisible = true;
                WriteLine(">> ");
                string command = Console.ReadLine();

                if (command == "Kill")
                {
                    if (myGame.MyEnemy != null)
                    {
                        myGame.MyEnemy.CurrentHealth = 0;
                        CmdActive = false;
                    }
                }
                else
                {
                    WriteLine("That is not a Command");
                    CmdActive = false;
                    break;
                }
            }
            CursorVisible = false;
        }
    
    async Task HandleInput()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = await ActivateCmdLine(); 

                if (keyInfo.Key == ConsoleKey.F1)
                {
                    CmdActive = true;
                    Console.WriteLine("Command mode activated.");
                    CmdLine();
                }          
            }
        }
        public Task<ConsoleKeyInfo> ActivateCmdLine()
        {
            var tcs = new TaskCompletionSource<ConsoleKeyInfo>();
            Thread inputThread = new Thread(() =>
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                tcs.SetResult(keyInfo);
            });
            inputThread.Start();
            return tcs.Task;

        }

    }
}
