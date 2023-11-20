using Funky_TextGame.StartFunctions;
using static System.Console;

namespace Funky_TextGame.CharacterList
{
    class DefaultPlayer : ParentCharacter
    {   
        public bool KeyHeld = false;
        public DefaultPlayer(Game Game) : base(Game)
        {
            //Constructor for the player character
            Description = "You the player";
            Level = 1;
            Armor = 0;
            StrengthStat -= 6;            
            HealthStat -= 5;                 
            Exp = 0;
            ReqExp = 100;
            MaxArmor = 10;
            HealthGrowth = 3;
            StrengthGrowth = 2;
            ArmorGrowth = 2;

            string Name;

            LevelAdjustments();
            StatAdjustments();
        }          

        public void BasicAttack()
        {
            if (myGame.MyEnemy.Armor < Damage)
            {
                myGame.MyEnemy.CurrentHealth -= Damage - myGame.MyEnemy.Armor;
            }
            else
            {
                WriteLine("Your attack was deflected");
            }
        }
        public void HeavyAttack()
        {
            if (myGame.MyEnemy.Armor < (Damage * 250) / 100)
            {
                myGame.MyEnemy.CurrentHealth -= Damage * 2 - myGame.MyEnemy.Armor;
                CurrentHealth -= (myGame.MyEnemy.Damage * 35) / 100;
            }
            else
            {
                WriteLine("Your attack was deflected");
            }
        }
        public void Defend()
        {
            Armor += 5 * Level;

            if (Armor > MaxArmor)
            {
                Armor = MaxArmor;
            }
        }
        public void Heal()
        {
            if (Mana > 15)
            {                
                CurrentHealth += HealAmount;
                Mana -= 15;

                if (CurrentHealth >= MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
            }
            else
            {
                WriteLine("Insufficient Mana");
            }
        }

        public override void LifeCheck()
        {
            if (CurrentHealth > 0)
            {
                Utilities.Delay("\nCongratulations on your victory");
                LevelCheck();
            }
            else
            {
                Utilities.Delay("\nThis is game over, you have failed your quest. The console will now close.");
                Utilities.Delay("\nPlease try again warrior");               
                Utilities.ExitConsole();
            }
        }          

    }
}
