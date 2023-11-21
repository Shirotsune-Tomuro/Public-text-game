using Funky_TextGame.AreaCollection;
using Funky_TextGame.CharacterList;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    class Combat : Area
    {
        //sets initiatl promts and options for the menu
        public string prompt2 = "";
        string option1 = "Attack";
        string option2 = "Defend";
        string option3 = "Heal";
        string option4 = "flee";
        bool AttackMenu = false;
        public int LogLength = 0;
        //Allows all information access through the "Game Class"
        public Combat(Game Game) : base(Game)
        {
            Name = "placeholder text";
            Description = "placeholder text 2";
        }
        override protected void Start()
        {
            //spawns an enemy from the game class and then strats combat            
            myGame.SpawnCharacters();
            StartCombat();
        }

        private void StartCombat()
        {
            do
            {
                //displays combat information and creates the menu every frame
                string prompt = $@"You have engaged in combat

    {myGame.MyDefaultPlayer.Name}          Enemy
 Level : {myGame.MyDefaultPlayer.Level}      Level  :   {myGame.MyEnemy.Level}
Health : {myGame.MyDefaultPlayer.CurrentHealth}     Health :   {myGame.MyEnemy.CurrentHealth}
Damage : {myGame.MyDefaultPlayer.Damage}    Damage :   {myGame.MyEnemy.Damage}
Armour : {myGame.MyDefaultPlayer.Armor}     Armour :   {myGame.MyEnemy.Armor}
  Mana : {myGame.MyDefaultPlayer.Mana}";
                string[] options = { option1, option2, option3, option4 };
                Menu mainMenu = new Menu(prompt, options, prompt2, myGame);
                int selectedIndex = mainMenu.Run();

                if (AttackMenu == false)
                {
                    //Main combat menu
                    switch (selectedIndex)
                    {
                        case (int)MenuOptions.attack:
                            {
                                //sets new menu options
                                option1 = "Slash";
                                option2 = "Charging BLow (Req Lvl 5)";
                                option3 = "Blazing Strike (Req Lvl 10)";
                                option4 = "Sorcery : Blood Sacrifice (Req Lvl 25)";
                                AttackMenu = true;
                            }
                            break;
                        case (int)MenuOptions.defend:
                            {
                                myGame.MyDefaultPlayer.Defend();
                            }
                            break;
                        case (int)MenuOptions.heal:
                            {
                                myGame.MyDefaultPlayer.Heal();
                            }
                            break;
                        case (int)MenuOptions.flee:
                            {
                                prompt2 = (prompt2 + "\nYou Attempt to flee... However, there is no way to flee.");
                                LogLength++;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    //Sub combat menu for attack commands
                    switch (selectedIndex)
                    {
                        case (int)AttackOptions.BasicAttack:
                            {
                                myGame.MyDefaultPlayer.BasicAttack();
                            }
                            break;
                        case (int)AttackOptions.HeavyAttack:
                            {
                                myGame.MyDefaultPlayer.HeavyAttack();
                            }
                            break;
                        case (int)AttackOptions.BlazingStrike:
                            {
                                myGame.MyDefaultPlayer.BlazingStrike();
                            }
                            break;
                        case (int)AttackOptions.SuperMove:
                            {
                                myGame.MyDefaultPlayer.SuperMove();
                            }
                            break;
                        default:
                            break;

                    }
                    //Resets menu options
                    AttackMenu = false;
                    option1 = "Attack";
                    option2 = "Defend";
                    option3 = "Heal";
                    option4 = "Flee";
                }
                //mana regen for the player
                myGame.MyDefaultPlayer.Mana += 5;
                if (myGame.MyDefaultPlayer.Mana >= myGame.MyDefaultPlayer.MaxMana)
                {
                    myGame.MyDefaultPlayer.Mana = myGame.MyDefaultPlayer.MaxMana;
                }
                // Prompts enemy action
                myGame.MyEnemy.RandomShenanigan();
                //Resets the prompt to empty every 5 lines
                ClearLog();
                //condition for combat to end
            } while (myGame.MyDefaultPlayer.CurrentHealth > 0 && myGame.MyEnemy.CurrentHealth > 0);
            EndCombat();

        }
        private void EndCombat()
        {
            Clear();
            for (int i = 0; i < myGame.MyCharacterList.Count; i++)
            {
                myGame.MyCharacterList[i].LifeCheck();
            }
            prompt2 = "";
            LogLength = 0;
            Utilities.KeyEntry();
            Clear();
        }
        private void ClearLog()
        {
            if (LogLength >= 6)
            {
                prompt2 = " ";
                LogLength = 0;
            }
        }
    }
}
