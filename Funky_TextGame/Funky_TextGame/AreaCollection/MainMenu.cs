using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.AreaCollection
{
    class MainMenu : Area
    {        
        public MainMenu(Game Game) : base(Game)
        {
            Name = "MainMenu";
            Description = "This is the MainMenu";
        }
        override protected void Start()
        {            
            string prompt = @"
 _______           _        _                  _________ _______          _________   _______  _______  _______  _______ 
(  ____ \|\     /|( (    /|| \    /\|\     /|  \__   __/(  ____ \|\     /|\__   __/  (  ____ \(  ___  )(       )(  ____ \
| (    \/| )   ( ||  \  ( ||  \  / /( \   / )     ) (   | (    \/( \   / )   ) (     | (    \/| (   ) || () () || (    \/
| (__    | |   | ||   \ | ||  (_/ /  \ (_) /      | |   | (__     \ (_) /    | |     | |      | (___) || || || || (__    
|  __)   | |   | || (\ \) ||   _ (    \   /       | |   |  __)     ) _ (     | |     | | ____ |  ___  || |(_)| ||  __)   
| (      | |   | || | \   ||  ( \ \    ) (        | |   | (       / ( ) \    | |     | | \_  )| (   ) || |   | || (      
| )      | (___) || )  \  ||  /  \ \   | |        | |   | (____/\( /   \ )   | |     | (___) || )   ( || )   ( || (____/\
|/       (_______)|/    )_)|_/    \/   \_/        )_(   (_______/|/     \|   )_(     (_______)|/     \||/     \|(_______/
                                                                                                                         ";
            string prompt2 = "Menu controls : [Up]  [Down]  [Enter]";
            string[] options = { "play", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options, prompt2, myGame);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    myGame.MyNameScreen.Run();
                    break;
                case 1:
                    myGame.MyAbout.Run();
                    break;
                case 2:
                    Utilities.ExitConsole();
                    break;
            }
        }
    }    

}
