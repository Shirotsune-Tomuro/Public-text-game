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
            Description = "The enemy";
            Name = "placeholder name";
            Level = 1;
            Armour = 0;
            StrengthStat = 5;            
            DexterityStat = 10;
            ManaStat = 10;
            HealthStat = 15;
            Damage = (int)(StrengthStat * Level * 0.9);
            MaxHealth = (int)(HealthStat * Level * 1.5);
            CurrentHealth = MaxHealth;
            Exp = 15;
                                   
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
            if (myGame.MyDefaultPlayer.Armour < Damage)
            {
                myGame.MyDefaultPlayer.CurrentHealth -= Damage - myGame.MyDefaultPlayer.Armour;
            }
            else
            {
                WriteLine("You defend against the enemy's attack");
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
        public void Flee()
        {

        }

        ~DefaultEnemy()
        {
            if (CurrentHealth > 0)
            {
                WriteLine("Enemy has successfully fled");

            }
            else
            {
                WriteLine("You have defeated the enemy");
                myGame.MyDefaultPlayer.Exp += Exp;
            }
        }
    }
}
