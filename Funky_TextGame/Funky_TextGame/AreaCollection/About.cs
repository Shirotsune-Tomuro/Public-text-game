using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.AreaCollection
{
    class About : Area
    {
        public About(Game Game) : base(Game) 
        {
             Name = "About page";
             Description = "Provides information about the game and its developer";
        }
        public override void Run()
        {
            RunAbout();
        }
        private void RunAbout()
        {       

            Clear();
            WriteLine(Description);
            Utilities.Delay("\n\nThis is a project created by I \"Ruben James Thompson\" for assignment 1 of \" Programming Foundations\" \n\n" +
                                  "During this project i had learned many things as i had limited foundational knowledge \n" +
                                  "Not only have I learned much about programming, but also about code formatting and keeping things tidy\n" +
                                  "I hope this project will not only allow a glimpse into what i have learned this semester\n" +
                                  "but also allow you to have a bit of fun :D" +
                                  "\n\n");
            Thread.Sleep(1000);
            WriteLine("Press any key to return");
            ReadKey(true);
            Clear();
            myGame.MyMainMenu.Run();
        }
    }
}
