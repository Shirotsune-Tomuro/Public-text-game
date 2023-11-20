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
        override protected void Start()
        {
            Clear();
            Utilities.Delay(@"You have awoken in a dark cave
you can't remember much other than your  name"
+
myGame.MyDefaultPlayer.Name);
            Utilities.KeyEntry();        
            
            Utilities.Delay("\n" + @"You decide to look around in order to get your bearings
However, there is some kind of creature within the darkness.
A menu appears that only you can see calling it a ""Slime""");
            Utilities.KeyEntry();

            Utilities.Delay(@"The slime plops towards you in exaggerated jiggly movements
You prepare your fists for this dangerous encounter.");
            
            Utilities.KeyEntry();
            myGame.MyCombat.Run();

            Utilities.Delay(@"Slime covers your hand after pummeling your foe
seeing no other slimes in this cave you find yourself in you deceide to explore");
            Utilities.KeyEntry();

            string prompt = "Where would you like to go?";
            string prompt2 = "";
            string[] options = { "North", "West", "South"};
            Menu mainMenu = new Menu(prompt, options, prompt2);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:                    
                    break;
                case 1:                    
                    break;
                case 2:
                    break;
            }
    }
}
