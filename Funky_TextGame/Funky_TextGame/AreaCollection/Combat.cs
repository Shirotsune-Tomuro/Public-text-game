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
            //sets initiatl promts and options for the menu
            string prompt2 = "";
            string option1 = "Attack";
            string option2 = "Defend";
            string option3 = "Flee";
            bool AttackMenu = false;

            do
            {
                //displays combat information and creates the menu every frame
                string prompt = $@"You have engaged in combat
Current Health : {myGame.MyDefaultPlayer.CurrentHealth}     Enemy Health :   {myGame.MyEnemy.CurrentHealth}
        Damage : {myGame.MyDefaultPlayer.Damage}";
                string[] options = { option1, option2, option3 };
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
                                option1 = "BasicAttack";
                                option2 = "HeavyAttack";
                                option3 = " ";
                                AttackMenu = true;
                            }
                            break;
                        case (int)MenuOptions.defend:
                            {
                                myGame.MyDefaultPlayer.Defend();
                                prompt2 = (prompt2 + "\nYou raise your guard");
                            }
                            break;
                        case (int)MenuOptions.flee:
                            {
                                prompt2 = (prompt2 + "\nYou Attempt to flee");
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
                            }
                            break;
                        case (int)AttackOptions.HeavyAttack:
                            {
                                myGame.MyDefaultPlayer.HeavyAttack();
                                prompt2 = (prompt2 + "\nYou take a heavy swing at the enemy");
                            }
                            break;
                        default:
                            break;

                    }
                    //Resets menu options
                    AttackMenu = false;
                    option1 = "Attack";
                    option2 = "Defend";
                    option3 = "Flee";
                }
                // Prompts enemy action
                myGame.MyEnemy.RandomShenanigan();
              //condition for combat to end
            } while (myGame.MyDefaultPlayer.CurrentHealth > 0 && myGame.MyEnemy.CurrentHealth > 0);
            EndCombat();         

        }
        public void EndCombat()
        {
            Clear();
            for (int i = 0; i < myGame.MyCharacterList.Count; i++)
            {
                myGame.MyCharacterList[i].LifeCheck();
            }
            WriteLine("\nyou have " + myGame.MyDefaultPlayer.Exp + "/" + myGame.MyDefaultPlayer.ReqExp + " exp");
        }


    }
}
