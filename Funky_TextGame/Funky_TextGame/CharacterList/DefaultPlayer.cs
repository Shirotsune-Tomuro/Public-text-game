using Funky_TextGame.StartFunctions;
using static System.Console;

namespace Funky_TextGame.CharacterList
{
    class DefaultPlayer : ParentCharacter
    {        
        public DefaultPlayer(Game Game) : base(Game)
        {
            //Constructor for the player character
            Description = "You the player";
            Level = 99;
            Armour = 0;
            StrengthStat -= 6;            
            HealthStat -= 5;                 
            Exp = 0;
            ReqExp = 100;
            MaxArmour = 10;
            HealthGrowth = 3;
            StrengthGrowth = 2;
            ArmourGrowth = 2;

            string Name;

            LevelAdjustments();
            StatAdjustments();
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
            if (myGame.MyEnemy.Armour < (Damage * 250) / 100)
            {
                myGame.MyEnemy.CurrentHealth -= Damage * 2 - myGame.MyEnemy.Armour;
                CurrentHealth -= (myGame.MyEnemy.Damage * 35) / 100;
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
        public void Heal()
        {
            if (Mana > 15)
            {                
                CurrentHealth = CurrentHealth + HealAmount;
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
