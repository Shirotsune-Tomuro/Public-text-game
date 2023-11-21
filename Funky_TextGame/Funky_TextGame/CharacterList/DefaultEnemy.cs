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
        int GenNum;
        public DefaultEnemy(Game Game) : base(Game)
        {            
            Description = "The enemy";
            Name = "placeholder name";

            GenerateNum();
            Level = GenNum;
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

        private void GenerateNum()
        {            
            var rand = new Random();
            GenNum = rand.Next(myGame.MyDefaultPlayer.Level - 3, myGame.MyDefaultPlayer.Level + 5);

            if (GenNum <= 0) 
            {
                GenNum = 1;
            }
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
            if (Damage >= myGame.MyDefaultPlayer.Armor)
            {
                var rand = new Random();
                int SelectedIndex = 0;
                SelectedIndex = rand.Next(5);

                switch (SelectedIndex)
                {
                    case 1:
                    case 2:
                    case 3:
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
            else
            {
                ArmorCrush();
            }
        }
        private void Attack()
        {
            if (Damage > myGame.MyDefaultPlayer.Armor)
            {
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nThe enemy attacks you";
                myGame.MyCombat.LogLength++;
                myGame.MyDefaultPlayer.CurrentHealth -= Damage - myGame.MyDefaultPlayer.Armor;
            }
            else
            {
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYou defend against the enemy's attack";
                myGame.MyCombat.LogLength++;
            }
        }
        private void Defend()
        {
            myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nThe enemy takes a defensive posture";
            myGame.MyCombat.LogLength++;
            Armor += 5 * (Level / 2);
            if (Armor > MaxArmor)
            {
                Armor = MaxArmor;
            }
        }
        private void Flee()
        {
            myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nThe enemy attempts to flee. However, the ability to flee is not implemented so you get a free action. Lucky you.";
            myGame.MyCombat.LogLength++;
        }
        private void ArmorCrush()
        {
            myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nThe Crushes your defenses";
            myGame.MyCombat.LogLength++;
            myGame.MyDefaultPlayer.Armor *= 70 / 100;
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
                myGame.MyDefaultPlayer.Gold += Gold;
            }
        }
    }
}
