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
            Name = "About";
            Description = "Provides information about the game and its developer";
        }
        public override void Run()
        {
            RunAbout();
        }
        private void RunAbout()
        {
            Clear();
            //await Utilities.Delay;
            WriteLine("This is a project created by I \"Ruben James Thompson\" for assignment 1 of \" Programming Foundations\" \n " +
                                  "During this project i had learned many things as i did not have much foundational knowledge in proggramming prior \n" +
                                  "Not only have I learned much about programming, i have also learned much about code formatting and how to keep things tidy \n" +
                                  "I hope this project will not only allow a glimpse into what i have learned this semester, but also allow you to \n" +
                                  "have a bit of fun :D");
            ReadKey(true);
            myGame.MyMainMenu.Run();
        }
    }
}
