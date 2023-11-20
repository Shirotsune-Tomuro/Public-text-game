using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    internal class Village : Area
    {
        public Village(Game Game) : base(Game)
        {
            Name = "Village";
            Description = "A not so peaceful village";
        }
        override protected void Start()
        {
            if (Completed == false)
            {
                Utilities.Delay(@"Saddened by the lack of a wolf pet, you proceed further through the forest.");
                Utilities.KeyEntry();

                Utilities.Delay(@"
You spot what appears to be a path and begin to follow it, hoping there might be a village or atleast another person.
Though as if you were cursed to have poor luck, a Thief has appeared on the path");
                Utilities.KeyEntry();

                Utilities.Delay(@"
""Ooh a traveller i see. Must be my lucky day""

You raise your fists to for the oncoming battle");
                Utilities.KeyEntry();

                myGame.MyCombat.Run();
                Completed = true;
            }
            else if (Completed == true)
            {
                Utilities.Delay(@"You have already saved the village, It's quite peaceful now.");
                Utilities.KeyEntry();
            }

            string prompt = "Where would you like to go?";
            string prompt2 = "";
            string[] options = { "Return to the path", "End Screen" };
            Menu mainMenu = new Menu(prompt, options, prompt2);
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
