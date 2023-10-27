using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funky_TextGame.AreaCollection;
using Funky_TextGame.CharacterList;
using Funky_TextGame.Funky_TextGame.AreaCollection;

namespace Funky_TextGame.StartFunctions
{
    class Game
    {
        //gives all levels access to the game class
        public MainMenu MyMainMenu;
        public About MyAbout;
        public Combat MyCombat;
        public Cave1 MyCave1;
        public DefaultPlayer MyDefaultPlayer;
        public DefaultEnemy MyEnemy;

        public Game()
        {
            MyMainMenu = new MainMenu (this);
            MyAbout = new About(this);
            MyCombat = new Combat(this);
            MyCave1 = new Cave1(this);
            MyDefaultPlayer = new DefaultPlayer(this);
            MyEnemy = new DefaultEnemy(this);
        }       

        // which level the game will start on
        public void Start()
        {
            MyMainMenu.Run();
        }
    }
}
