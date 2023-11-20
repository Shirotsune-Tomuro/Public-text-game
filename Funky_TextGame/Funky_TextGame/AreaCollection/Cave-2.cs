﻿using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    internal class Cave_2 : Area
    {       
        public Cave_2(Game Game) : base(Game)
        {
            Name = "Cave - 2";
            Description = "A dark dank cave filled with an evil aura";
        }
        override protected void Start()
        {
            Utilities.Delay($@"You have entered further into the cave
There is a sign on the groud with a message written on it

""Dev Note - this place is designed to test your skill in combat
do not enter this place recklessly""");

            Utilities.KeyEntry();

            do
            {
                string prompt = "Do you wish to continue?";
                string prompt2 = "";
                string[] options = { "Yes", "No" };
                Menu mainMenu = new Menu(prompt, options, prompt2);
                int selectedIndex = mainMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        {                           
                            myGame.MyCombat.Run();
                        }
                        break;
                    case 1:
                        {                            
                            myGame.MyCave1.Run();
                        }
                        break;
                }
            }while (true);

        }
    }
}