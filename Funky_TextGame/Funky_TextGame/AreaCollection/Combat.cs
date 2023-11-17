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
            string prompt2 = "";
            string option1 = "Attack";
            string option2 = "Defend";
            string option3 = "Heal";
            string option4 = "flee";
            bool AttackMenu = false;
            int LogLength = 0;
        //Allows all information access through the "Game Class"
        public Combat(Game Game) : base(Game)
        {
            Name = "placeholder text";
            Description = "placeholder text 2";       
        }


        public override void Run()
        {
            CombatSetup();
        }
        private void CombatSetup()
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

    Player          Enemy
 Level : {myGame.MyDefaultPlayer.Level}      Level  :   {myGame.MyEnemy.Level}
Health : {myGame.MyDefaultPlayer.CurrentHealth}     Health :   {myGame.MyEnemy.CurrentHealth}
Damage : {myGame.MyDefaultPlayer.Damage}    Damage :   {myGame.MyEnemy.Damage}
Armour : {myGame.MyDefaultPlayer.Armour}     Armour :   {myGame.MyEnemy.Armour}
  Mana : {myGame.MyDefaultPlayer.Mana}";
                string[] options = { option1, option2, option3, option4};
                Menu mainMenu = new Menu(prompt, options, prompt2);
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
                                option2 = "Charging Strike";
                                option3 = " ";
                                option4 = " ";
                                AttackMenu = true;
                            }
                            break;
                        case (int)MenuOptions.defend:
                            {
                                myGame.MyDefaultPlayer.Defend();
                                prompt2 = (prompt2 + "\nYou raise your guard");
                                LogLength++;
                            }
                            break;                      
                        case (int)MenuOptions.heal:
                            {
                                myGame.MyDefaultPlayer.Heal();
                                prompt2 = (prompt2 + "\n You Sip on your healing flask");
                                LogLength++;
                            }
                            break;  
                        case (int)MenuOptions.flee:
                            {
                                prompt2 = (prompt2 + "\nYou Attempt to flee");
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
                                prompt2 = (prompt2 + "\nYou slash your opponent");
                                LogLength++;
                            }
                            break;
                        case (int)AttackOptions.HeavyAttack:
                            {
                                myGame.MyDefaultPlayer.HeavyAttack();
                                prompt2 = (prompt2 + "\nYou take a heavy swing at the enemy");
                                LogLength++;
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
