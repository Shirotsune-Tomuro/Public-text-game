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
    internal class Forest_1 : Area
    {
        public Forest_1(Game Game) : base(Game)
        {
            Name = "Forest";
            Description = "The forest surrounding the cave";
        }

        override protected void Start(int eLevel)
        {
            Clear();
            if (Completed == false)
            {
                Utilities.Delay(@"You successfully make your way out of the cave and are greeted by a verdant green forest
It's quite nice. Large tall trees, lush bushes with berries and small creatures");
                Utilities.KeyEntry();

                Utilities.Delay(@"Whilst taking in the sights a wolf approaches you
Thankfully it's a friendly wolf and asks for you to pet it");
                Utilities.KeyEntry();

                Utilities.Delay(@"Unfortunately for you a ""Goblin"" has decided to take an interest in you
The wolf runs away and you're forced to fight");
                Utilities.KeyEntry();                
                myGame.MyCombat.Run(5);
                Completed = true;
            }
            else if (Completed == true)
            {
                Utilities.Delay(@"You return to the depts of the forest
The ""Goblin"" seems to have returned. It looks about as strong as you do");
                Utilities.KeyEntry();
                myGame.MyModTools.GenerateLevel();
                myGame.MyCombat.Run(myGame.MyModTools.GenNum);
            }

            string prompt = "Where would you like to go?";
            string prompt2 = "";
            string[] options = { "Towards the cave - [Level 1]", "Towards the edge of the forest - [Level 10]" };
            Menu mainMenu = new Menu(prompt, options, prompt2, myGame);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        myGame.MyCave1.Run(1);
                    }
                    break;
                case 1:
                    {
                        myGame.MyForest_2.Run(1);
                    }
                    break;
            }
        }

    }
}
