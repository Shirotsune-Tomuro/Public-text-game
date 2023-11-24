using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    internal class Mega_Boss : Area
    {
        public Mega_Boss(Game Game) : base(Game)
        {
            Name = "Mega Boss";
            Description = "A final challenge";
        }

        protected override void Start(int eLevel)
        {
            Clear();
            if (Completed == false)
            {
                Utilities.Delay($@"You Approach a wooden door with a note attached

""Dev Note - this place is the ultimate test of you combat prowess 
As such, this door is locked until you can prove yourself [Level ??? - Key Required!]""");

                Utilities.KeyEntry();

                string prompt = "Do you wish to enter?";
                string prompt2 = "";
                string[] options = { "Yes", "No" };
                Menu mainMenu = new Menu(prompt, options, prompt2, myGame);
                int selectedIndex = mainMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        {
                            if (myGame.MyDefaultPlayer.KeyHeld == true)
                            {
                                BossEncounter();
                                Completed = true;
                            }
                            else
                            {
                                Utilities.Delay("This door is locked");
                                Utilities.KeyEntry();
                                myGame.MyCave1.Run(default);
                            }
                        }
                        break;
                    case 1:
                        {
                            myGame.MyCave1.Run(default);
                        }
                        break;
                }
            }
            else if (Completed == true)
            {
                Utilities.Delay("You already beat the Boss, there's nothing else to do here");
                Utilities.KeyEntry();
                myGame.MyCave1.Run(default);
            }

        }

        private void BossEncounter()
        {
            Utilities.Delay($@"{myGame.MyDefaultPlayer.Name}... This truly is the final boss of this game. 
Getting here was no easy feat and you have fought hard to get to where you are.
I would like you to know that i am proud of your accomplishments thus far.

And now... you must face the ""Dragon of Ruin"". I sincerely hope you are prepared.");
            Utilities.KeyEntry();
            myGame.MyCombat.Run(25);

            Utilities.Delay($@"My goodness {myGame.MyDefaultPlayer.Name}, you did it...
Now the world will no longer be threatened by this menace. Thank you");
            Utilities.KeyEntry();

            Utilities.Delay(@"Here's an extra thank you from me the developer
Thank you for playing through my game until the end
Unfortunately, this actually is the end, all of the enemies now only scale off of the player level
So feel free to continue grinding. I will be sending you back to the main menu first though.");
            Utilities.KeyEntry();
            myGame.MyMainMenu.Run(default);

        }
    }
}
