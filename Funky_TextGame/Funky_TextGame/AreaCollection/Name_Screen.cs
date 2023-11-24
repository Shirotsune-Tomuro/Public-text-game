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
    internal class Name_Screen : Area
    {
        public bool nameset = false;
        public Name_Screen(Game Game) : base(Game)
        {
            Name = "Name_Screen";
            Description = "A Place to name your player";            
        }
        protected override void Start(int eLevel)
        {
            Clear();
            Utilities.Delay($@"Welcome to Funky Text Game adventurer
Before we get into the main game, please name yourself" + "\n\n"); 
            

            do
            {
                CursorVisible = true;
                Write(">> ");
                myGame.MyDefaultPlayer.Name = ReadLine();
                CursorVisible = false;

                string prompt = myGame.MyDefaultPlayer.Name + " Is it?";
                string prompt2 = "";
                string[] options = { "Yes", "No" };
                Menu mainMenu = new Menu(prompt, options, prompt2, myGame);
                int selectedIndex = mainMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        nameset = true;
                        break;
                    case 1:
                        Utilities.Delay("It's not? well what is it then?\n\n");
                        break;
                }
            }while (nameset == false);

            Utilities.Delay("Brilliant. Let's get started then");
            Utilities.KeyEntry();
            myGame.MyCave1.Run(default);
                    
        }
    }
}
