using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    internal class EndCredits : Area
    {
        public EndCredits(Game Game) : base(Game)
        {
            Name = "EndCredits";
            Description = "The end of a journey";
        }

        protected override void Start()
        {
            Utilities.Delay($@"So {myGame.MyDefaultPlayer.Name}, you've reched the end huh
Good job. there's nothing left to do now other than continuing levelling.");
            Utilities.KeyEntry();

            string prompt = "Would you like to continue a bit more??";
            string prompt2 = "";
            string[] options = { "Yes", "No" };
            Menu mainMenu = new Menu(prompt, options, prompt2);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        Utilities.Delay("In that case, I shall send you back to the start of your journey to take on the last challenges");
                        Utilities.KeyEntry();
                        myGame.MyCave1.Run();
                    }
                    break;
                case 1:
                    {
                        Utilities.Delay("Until next time " + myGame.MyDefaultPlayer.Name);
                        Utilities.KeyEntry();
                        Utilities.ExitConsole();
                    }
                    break;
            }
        }
    }
}
