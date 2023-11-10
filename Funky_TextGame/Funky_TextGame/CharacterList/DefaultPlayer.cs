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
    class DefaultPlayer : ParentCharacter
    {
        public DefaultPlayer(Game Game) : base(Game)
        {
            //Constructor for the player character
            Description = "You the player";
            Level = 14;
            Armour = 0;
            StrengthStat = 6;
            DexterityStat = 10;
            ManaStat = 10;
            HealthStat = 15;
            Damage = (int)(StrengthStat * Level);
            MaxHealth = (int)(HealthStat * Level);
            CurrentHealth = MaxHealth;
            Exp = 0;
            ReqExp = 100;
            MaxArmour = 10;

        }    
        

        public void BasicAttack()
        {
            if (myGame.MyEnemy.Armour < Damage)
            {
                myGame.MyEnemy.CurrentHealth -= Damage - myGame.MyEnemy.Armour;
            }
            else
            {
                WriteLine("Your attack was deflected");
            }
        }
        public void HeavyAttack()
        {
            if (myGame.MyEnemy.Armour < Damage * 2)
            {
                myGame.MyEnemy.CurrentHealth -= Damage * 2 - myGame.MyEnemy.Armour;
                CurrentHealth -= myGame.MyEnemy.Damage / 2;
            }
            else
            {
                WriteLine("Your attack was deflected");
            }
        }
        public void Defend()
        {
            Armour += 5;

            if (Armour > MaxArmour)
            {
                Armour = MaxArmour;
            }
        }

        public override void LifeCheck()
        {
            if (CurrentHealth > 0)
            {
                WriteLine("\nCongratulations on your victory");
                LevelCheck();
            }
            else
            {
                WriteLine("\nThis is game over, please exit the console to play again");
            }
        }     
        private void LevelCheck()
        {
            if (Exp >= ReqExp)
            {   
                Exp = 0;   
                Level += 1;          
                WriteLine("\nYou have reached level " + Level + ". Congratulations!");                
                ReqExp = (int)(ReqExp * 1.5);                
                LevelUp();
            }            
        }
        private void LevelUp()
        {
            
            HealthStat += 1;
            StrengthStat += 2;
            Armour += 4;
            MaxArmour += 4;
            CurrentHealth = MaxHealth;
            
        }



    }
}
