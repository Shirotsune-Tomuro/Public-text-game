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
        override protected void Start(int eLevel)
        {
            Clear();
            if (Completed == false)
            {
                Clear();
                Utilities.Delay($@"You have awoken in a dark cave
Unable to remember much other than your name ""{myGame.MyDefaultPlayer.Name}""");
                Utilities.KeyEntry();

                Utilities.Delay(@"You decide to look around in order to get your bearings
However, there is some kind of creature within the darkness
It's a ""Slime""");
                Utilities.KeyEntry();

                Utilities.Delay(@"The slime plops towards you in exaggerated jiggly movements
You prepare your fists for this dangerous encounter");
                Utilities.KeyEntry();

                myGame.MyCombat.Run(1);
                Completed = true;

                Utilities.Delay(@"Slime covers your hand after pummeling your foe
Seeing no other slimes in this cave you find yourself in, you decide to explore");
                Utilities.KeyEntry();
            }
            else if (Completed == true)
            {
                Utilities.Delay(@"You return to the entrance of the cave
The slime is back somehow. It looks about as strong as you do");
                Utilities.KeyEntry();
                myGame.MyModTools.GenerateLevel();
                myGame.MyCombat.Run(myGame.MyModTools.GenNum);
            }

            string prompt = "Where would you like to go?";
            string prompt2 = "";
            string[] options = { "Towards a faint breeze - [Level 5]", "A suspicious looking door", "Further into the cave - [Training]" };
            Menu mainMenu = new Menu(prompt, options, prompt2, myGame);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        myGame.MyForest_1.Run(default);
                    }
                    break;
                case 1:
                    {
                        myGame.MyMegaBoss.Run(default);
                    }
                    break;
                case 2:
                    {
                        myGame.MyCave_2.Run(default);
                    }
                    break;
            }
        }
    }
}
