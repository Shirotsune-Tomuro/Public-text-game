using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    internal class Village : Area
    {
        public Village(Game Game) : base(Game)
        {
            Name = "Village";
            Description = "A not so peaceful village";
        }
        override protected void Start(int eLevel)
        {
            Clear();
            if (Completed == false)
            {
                Utilities.Delay(@"You reach what appeared to be a village. However there are no people to be seen");
                Utilities.KeyEntry();

                Utilities.Delay(@"The cry of a woman rings from the vilage square
There is an ogre thrashing around a large club, destroying everything in sight
A villager can be seen quickly closing their window, it seems they have all locked themselves in their homes");
                Utilities.KeyEntry();

                Utilities.Delay(@"""Grog hungry!!!""");
                Utilities.KeyEntry();
                
                myGame.MyCombat.Run(15);


                Utilities.Delay("you have obtained a strange key");
                myGame.MyDefaultPlayer.KeyHeld = true;

                Utilities.KeyEntry();
                Completed = true;
            }
            else if (Completed == true)
            {
                Utilities.Delay(@"You have already saved the village, It's quite peaceful now");
                Utilities.KeyEntry();
            }

            string prompt = "Where would you like to go?";
            string prompt2 = "";
            string[] options = { "Return to the path", "End Screen" };
            Menu mainMenu = new Menu(prompt, options, prompt2, myGame);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {                        
                        Utilities.KeyEntry();
                        myGame.MyForest_2.Run(default);
                    }
                    break;
                case 1:
                    {
                        myGame.MyEndCredits.Run(default);
                    }
                    break;
            }
        }
    }
}
