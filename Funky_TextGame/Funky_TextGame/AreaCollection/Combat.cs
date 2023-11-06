using Funky_TextGame.AreaCollection;
using Funky_TextGame.CharacterList;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    class Combat : Area
    {

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
            myGame.SpawnEnemy();
            StartCombat();
        }

        private void StartCombat()
        {
            string prompt2 = "";
            string option1 = "Attack";
            string option2 = "Defend";
            string option3 = "Flee";
            bool AttackMenu = false;

            do
            {
                string prompt = $@"You have engaged in combat
Current Health : {myGame.MyDefaultPlayer.CurrentHealth}     Enemy Health :   {myGame.MyEnemy.CurrentHealth}
        Damage : {myGame.MyDefaultPlayer.Damage}";
                string[] options = { option1, option2, option3 };
                Menu mainMenu = new Menu(prompt, options, prompt2);
                int selectedIndex = mainMenu.Run();

                if (AttackMenu == false)
                {

                    switch (selectedIndex)
                    {
                        case (int)MenuOptions.attack:
                            {
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
                    AttackMenu = false;
                    option1 = "Attack";
                    option2 = "Defend";
                    option3 = "Flee";
                }

                myGame.MyEnemy.RandomShenanigan();

            } while (myGame.MyDefaultPlayer.CurrentHealth > 0 && myGame.MyEnemy.CurrentHealth > 0);

        }


    }
}
