using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funky_TextGame.AreaCollection;

namespace Funky_TextGame.StartFunctions
{
    class Game
    {
        //gives all levels access to the game class
        public MainMenu MyMainMenu;
        public About MyAbout;

        public Game()
        {
            MyMainMenu = new MainMenu (this);
            MyAbout = new About(this);
        }

        // which level the game will start on
        public void Start()
        {
            MyMainMenu.Run();
        }
    }
}
