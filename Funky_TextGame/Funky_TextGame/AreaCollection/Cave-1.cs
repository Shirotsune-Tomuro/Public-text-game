using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    class Cave1 : Area
    {
        public Cave1(Game Game) : base(Game)
        {
            Name = "Cave - 1";
            Description = "A dark dank cave";            
        }

        public override void Run()
        {
            StartCave();
        }

        private void StartCave()
        {
            Clear();
            WriteLine("testing start");
            Utilities.KeyEntry();
            myGame.MyCombat.Run();
            WriteLine("test complete");
            WriteLine("help please");
            WriteLine("another change?");
            WriteLine("Let me commit to git");
            Utilities.KeyEntry();
            myGame.MyMainMenu.Run();
        }
    }
}
