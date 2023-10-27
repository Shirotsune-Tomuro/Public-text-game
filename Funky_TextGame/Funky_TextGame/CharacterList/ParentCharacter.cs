using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.CharacterList
{
    class ParentCharacter
    {
        protected Game myGame;

        public String Name;
        public String Description;
        public int Strength;
        public int Dexterity;
        public int Mana;
        public int Health;
        public int Armour;
        public int Level;

        //all levels pass throught the game class
        public ParentCharacter(Game Game)
        {
            myGame = Game;
        }
        //this can be edited per child
        virtual public void Run()
        {

        }
    }
}

