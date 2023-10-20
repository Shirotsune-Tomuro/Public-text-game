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


        public override void Run()
        {
            RunMainMenu();
        }

        private void RunMainMenu()
        {            
            string prompt = "Welcome to Funky Text Game, What would you like to do?\n";
            string[] options = { "play", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    // something will go here
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
