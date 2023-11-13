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
            Level = 50;
            Armour = 0;
            StrengthStat -= 6;            
            HealthStat -= 5;                 
            Exp = 0;
            ReqExp = 100;
            MaxArmour = 10;
            HealthGrowth = 1;
            StrengthGrowth = 2;
            ArmourGrowth = 7;             
            StatAdjustments();
            LevelAdjustments();
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
            Armour += 5 * Level;

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

    }
}
