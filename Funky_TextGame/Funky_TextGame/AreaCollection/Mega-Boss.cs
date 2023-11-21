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

        protected override void Start()
        {
            Clear();
            if (Completed == false)
            {
                Utilities.Delay($@"You Approach a wooden door with a note attached.

""Dev Note - this place is the ultimate test of you combat prowess. 
As such, this door is locked until you can prove yourself.""");

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
                                myGame.MyCombat.Run();
                                Completed = true;
                            }
                            else
                            {
                                Utilities.Delay("This door is locked");
                                Utilities.KeyEntry();
                                myGame.MyCave1.Run();
                            }
                        }
                        break;
                    case 1:
                        {
                            myGame.MyCave1.Run();
                        }
                        break;
                }
            }
            else if (Completed == true)
            {
                Utilities.Delay("You already beat the Boss, there's nothing else to do here");
                Utilities.KeyEntry();
                myGame.MyCave1.Run();
            }

        }
    }
}
