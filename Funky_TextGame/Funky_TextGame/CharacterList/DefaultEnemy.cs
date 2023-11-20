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
            Armor = 0;
            StrengthStat -= 8;              
            HealthStat += 10;
            HealthGrowth = 7;
            StrengthGrowth = 1;
            ArmorGrowth = 2;
            Gold = 10;
            GoldGrowth = 1;
            
            Exp = 15 * Level;
            StatAdjustments();
            LevelAdjustments();
        }
        override protected void StatAdjustments()
        {
            Damage = ((StrengthStat * 10) * 32) / 100;
            MaxHealth = ((HealthStat * 10) * 173) / 100;
            CurrentHealth = MaxHealth;
            MaxArmorGrowth = (ArmorGrowth * 2);
            Exp = (Exp * 135) / 100;

            if (Level >= LevelCapstone)
            {
                HealthGrowth += 3;
                ArmorGrowth += 1;                
                LevelCapstone += 10;
            }
        
        }

        public void RandomShenanigan()
        {
            var rand = new Random();
            int SelectedIndex = 0;
            SelectedIndex = rand.Next(5);

            switch (SelectedIndex) 
            {
                case 1 :
                case 2 :
                case 3 :
                    Attack();
                break;          
                case 4:
                    Defend();
                break;
                case 5:
                    Flee();
                break;
                default:
                break;
            }
        }
        public void Attack()
        {
            if (Damage > myGame.MyDefaultPlayer.Armor )
            {
                WriteLine("\nThe enemy attacks you");
                myGame.MyDefaultPlayer.CurrentHealth -= Damage - myGame.MyDefaultPlayer.Armor;
            }
            else
            {
                WriteLine("\nYou defend against the enemy's attack");
            }
        }
        public void Defend()
        {
            WriteLine("\nThe enemy takes a defensive posture");
            Armor += 5 * 10;
            if (Armor > MaxArmor)
            {
                Armor = MaxArmor;
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
