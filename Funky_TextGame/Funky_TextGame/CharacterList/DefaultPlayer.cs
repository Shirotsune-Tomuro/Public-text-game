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
            // filling in the variables from the parent class
            Description = "You the player";
            Level = 1;
            Armour = 0;
            StrengthStat = 6;
            DexterityStat = 10;
            ManaStat = 10;
            HealthStat = 10;
            Damage = (int)(StrengthStat * Level);
            MaxHealth = (int)(HealthStat * Level);
            CurrentHealth = MaxHealth;
            Exp = 0;
            ReqExp = 100;
            MaxArmour = 10;

        }       
        public override void LifeCheck()
        {
            
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

        ~DefaultPlayer()
        {
            WriteLine("This is game over, please exit the console to play again");
        }


    }
}
