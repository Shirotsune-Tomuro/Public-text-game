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

        public String Name = "";
        public String Description = "";
        public int StrengthStat = 0;
        public int WeaponPower = 0;
        public int Damage = 0;
        public int DexterityStat = 0;
        public int ManaStat = 0;
        public int HealthStat = 0;
        public int MaxHealth = 0;
        public int CurrentHealth = 0;   
        public int Armour = 0;
        public int Level = 0;
        public int Exp = 0;
        public int ReqExp = 0;
        public int MaxArmour = 0;     

        //all characters pass throught the game class
        public ParentCharacter(Game Game)
        {
            myGame = Game;
        }
        //this can be edited per child      
        virtual public void LifeCheck()
        {

        }
    }
}

