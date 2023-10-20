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
            
        }
        public override void Run()
        {
            RunAbout();
        }
        private async void RunAbout()
        {
            Name = "About page";
            Description = "Provides information about the game and its developer";


            Clear();
            WriteLine(Description);
            WriteLine("\n\nThis is a project created by I \"Ruben James Thompson\" for assignment 1 of \" Programming Foundations\" \n" +
                                  "During this project i had learned many things as i did not have much foundational knowledge \n" +
                                  "in proggramming prior Not only have I learned much about programming, i have also learned \n" +
                                  "much about code formatting and how to keep things tidy I hope this project will not only allow \n" +
                                  "a glimpse into what i have learned this semester, but also allow you to have a bit of fun :D" +
                                  "\n\n");
            Thread.Sleep(1000);
            WriteLine("Press any key to return");
            ReadKey(true);
            myGame.MyMainMenu.Run();
        }
    }
}
