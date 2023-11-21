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
    internal class Forest_2 : Area
    {
        public Forest_2(Game Game) : base(Game)
        {
            Name = "Forest";
            Description = "A part of the forest nearing the edge";
        }

        override protected void Start()
        {
            Clear();
            if (Completed == false)
            {
                Utilities.Delay(@"Saddened by the lack of a wolf pet, you proceed further through the forest.");
                Utilities.KeyEntry();

                Utilities.Delay(@"You spot what appears to be a path and begin to follow it, hoping there might be a village or atleast another person.
Though as if you were cursed to have poor luck, a Thief has appeared on the path");
                Utilities.KeyEntry();

                Utilities.Delay(@"""Ooh a traveller i see. Must be my lucky day""

You raise your fists to for the oncoming battle");
                Utilities.KeyEntry();

                myGame.MyCombat.Run();
                Completed = true;
            }        
            else if (Completed == true)
            {
                Utilities.Delay(@"You return to the forest path anticipating a fight...

There's nothing to do here, people don't come back from the dead silly");
                Utilities.KeyEntry();                
            }

            string prompt = "Where would you like to go?";
            string prompt2 = "";
            string[] options = { "Towards the caravn at the side of the path", "Towards the village past the caravan" };
            Menu mainMenu = new Menu(prompt, options, prompt2, myGame);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        myGame.MyShop.Run();
                    }
                    break;
                case 1:
                    {
                        myGame.MyVillage.Run();
                    }
                    break;
            }
        }
    }
}
