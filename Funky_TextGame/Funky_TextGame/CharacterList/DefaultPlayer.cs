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
            Level = 99;
            Armor = 0;
            StrengthStat -= 6;
            HealthStat -= 5;
            Exp = 0;
            ReqExp = 100;
            MaxArmor = 10;
            HealthGrowth = 3;
            StrengthGrowth = 1;
            ArmorGrowth = 1;

            LevelAdjustments();
            StatAdjustments();
        }
        //standard attack 
        public void BasicAttack()
        {
            if (myGame.MyEnemy.Armor < Damage)
            {
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYou slash your opponent";
                myGame.MyCombat.LogLength++;
                myGame.MyEnemy.CurrentHealth -= Damage - myGame.MyEnemy.Armor;
            }
            else
            {
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYour attack was deflected";
                myGame.MyCombat.LogLength++;
            }
        }
        //strong attack that causes true damage to the player
        public void HeavyAttack()
        {
            if (Level >= 5)
            {
                if (myGame.MyEnemy.Armor < (Damage * 250) / 100)
                {
                    myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYou take a heavy swing at the enemy";
                    myGame.MyCombat.LogLength++;
                    myGame.MyEnemy.CurrentHealth -= (Damage * 250) / 100 - myGame.MyEnemy.Armor;
                    CurrentHealth -= (myGame.MyEnemy.Damage * 35) / 100;
                }
                else
                {
                    myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYour attack was deflected";
                    myGame.MyCombat.LogLength++;
                }
            }
            else
            {
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYour Level is too low";
                myGame.MyCombat.LogLength++;
            }
        }
        //uses player mana to attack
        public void BlazingStrike()
        {
            if (Level >= 10)
            {
                if (Mana >= 50)
                {
                    myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYou light your sword aflame with mana and strike your foe";
                    myGame.MyCombat.LogLength++;
                    myGame.MyEnemy.CurrentHealth -= Damage * 4 - myGame.MyEnemy.Armor;
                    Mana -= 50;
                }
                else
                {
                    myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nInsufficient Mana";
                    myGame.MyCombat.LogLength++;
                }
            }
            else
            {
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYour Level is too low";
                myGame.MyCombat.LogLength++;
            }
        }
        //uses the players health and mana to attack
        public void SuperMove()
        {
            if (Level >= 25)
            {
                if (Mana >= 100)
                {
                    myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYou sacrifice your lifeforce for a deadly blow";
                    myGame.MyCombat.LogLength++;
                    myGame.MyEnemy.CurrentHealth -= Damage * 10 - myGame.MyEnemy.Armor;
                    CurrentHealth -= 400;
                    Mana -= 100;
                }
                else
                {
                    myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nInsufficient Mana";
                    myGame.MyCombat.LogLength++;
                }
            }
            else
            {
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYour Level is too low";
                myGame.MyCombat.LogLength++;
            }
        }
        //increases player defence by a percentage of max defence
        public void Defend()
        {
            if ((MaxArmor * 5) / 100 > 5)
            {
                Armor += (MaxArmor * 5) / 100;
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYou raise your guard";
                myGame.MyCombat.LogLength++;

                if (Armor > MaxArmor)
                {
                    Armor = MaxArmor;
                }
            }
            else 
            {
                Armor += 5;
            }
        }
        //heals player using mana
        public void Heal()
        {
            if (Mana > 35)
            {
                myGame.MyCombat.prompt2 = (myGame.MyCombat.prompt2 + "\nYou Sip on your healing flask");
                myGame.MyCombat.LogLength++;
                CurrentHealth += HealAmount;
                Mana -= 35;

                if (CurrentHealth >= MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
            }
            else
            {
                myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nInsufficient Mana";
                myGame.MyCombat.LogLength++;
            }
        }
        public void ArmorCrush()
        {
            myGame.MyCombat.prompt2 = myGame.MyCombat.prompt2 + "\nYou disrupt the enemy defensive stance";
            myGame.MyCombat.LogLength++;
            myGame.MyEnemy.Armor -= (myGame.MyEnemy.Armor * 60) / 100;
        }

        //checks if the player is alive
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
