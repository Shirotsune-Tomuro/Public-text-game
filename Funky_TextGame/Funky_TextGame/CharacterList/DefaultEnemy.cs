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
    class DefaultEnemy : ParentCharacter
    {
        public DefaultEnemy(Game Game) : base(Game)
        {
            var rand = new Random();
            Description = "The enemy";
            Name = "placeholder name";
            Level = rand.Next(myGame.MyDefaultPlayer.Level - 3, myGame.MyDefaultPlayer.Level + 5);
            Armour = 0;
            StrengthStat -= 8;              
            HealthStat += 10;
            HealthGrowth = 1;
            StrengthGrowth = 1;
            ArmourGrowth = 3;
            
            Exp = (15 * 10);
            StatAdjustments();
            LevelAdjustments();
        }
        override protected void StatAdjustments()
        {
            Damage = (int)(StrengthStat * 10 * 0.9);
            MaxHealth = (int)(HealthStat * 10 * 2.5);
            CurrentHealth = MaxHealth;
            MaxArmourGrowth = (int)(ArmourGrowth * 1.5);
        }

        public void RandomShenanigan()
        {
            var rand = new Random();
            int SelectedIndex = 0;
            SelectedIndex = rand.Next(4);

            switch (SelectedIndex) 
            {
                case 1:
                    Attack();
                break;
                case 2:
                    Defend();
                break;
                case 3:
                    Flee();
                break;
                default:
                break;
            }
        }
        public void Attack()
        {
            if (Damage > myGame.MyDefaultPlayer.Armour )
            {
                WriteLine("\nThe enemy attacks you");
                myGame.MyDefaultPlayer.CurrentHealth -= Damage - myGame.MyDefaultPlayer.Armour;
            }
            else
            {
                WriteLine("\nYou defend against the enemy's attack");
            }
        }
        public void Defend()
        {
            WriteLine("\nThe enemy takes a defensive posture");
            Armour += 5 * 10;
            if (Armour > MaxArmour)
            {
                Armour = MaxArmour;
            }
        }
        public void Flee()
        {
            WriteLine("\nThe enemy attempts to flee. However, the ability to flee is not implemented so you get a free action. Lucky you.");
        }

        public override void LifeCheck()
        {
            if (CurrentHealth > 0)
            {
                WriteLine("\nEnemy has successfully fled");

            }
            else
            {               
                myGame.MyDefaultPlayer.Exp += Exp;
            }
        }
    }
}
