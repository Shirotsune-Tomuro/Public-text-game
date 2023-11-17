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
        public int StrengthStat = 10;
        public int WeaponPower = 0;
        public int Damage = 0;        
        public int HealthStat = 10;
        public int MaxHealth = 0;
        public int CurrentHealth = 0;   
        public int Armour = 0;
        public int Level = 0;
        public int Exp = 0;
        public int ReqExp = 0;
        public int MaxArmour = 0;
        public int HealthGrowth = 0;
        public int StrengthGrowth = 0;
        public int ArmourGrowth = 0;
        public int MaxArmourGrowth = 0;
        public int HealAmount = 0;
        public int Mana = 100;
        public int MaxMana = 100;
        public int LevelCapstone = 10;

        //all characters pass throught the game class
        public ParentCharacter(Game Game)
        {
            myGame = Game;
        }
        //this can be edited per child      
        virtual public void LifeCheck()
        {

        }
        protected void LevelAdjustments()
        {
            for (int i = 1; i < Level; i++)
            {
                LevelUp();
            }
        }
        virtual protected void StatAdjustments()
        {
            Damage = ((StrengthStat * 10) * 113) / 100;
            MaxHealth = ((HealthStat * 10) * 102) / 100;
            CurrentHealth = MaxHealth;
            MaxArmourGrowth = ArmourGrowth * 1;
            HealAmount = (MaxHealth * 35) / 100;
        }
        protected void LevelUp()
        {            
            HealthStat += HealthGrowth;
            StrengthStat += StrengthGrowth;
            Armour += ArmourGrowth;
            MaxArmour += MaxArmourGrowth;
            ReqExp = (ReqExp * 175) / 100;
            StatAdjustments();

        }
        protected void LevelCheck()
        {
            if (Exp >= ReqExp)
            {
                do
                {
                    Exp -= ReqExp;
                    Level += 1;
                    WriteLine("\nYou have reached level " + Level + ". Congratulations!");                    
                    LevelUp();

                } while (Exp >= ReqExp);
            }
            else
            {
                WriteLine("\nYou have " + Exp + "/" + ReqExp + " Exp");
            }
        }
    }
}

