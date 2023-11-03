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
            for (int i = 0; i < 3; i++)
            {
                myGame.SpawnEnemy();
            }
            StartCombat();
        }   

        private void StartCombat()
        { 
            string prompt2 = "";
            string option1 = "Attack";          
            string option2 = "Defend";          
            string option3 = "Flees";



            do
            {
                string prompt = $@"You have engaged in combat
Current Health : {myGame.MyDefaultPlayer.CurrentHealth}     Enemy Health :   {myGame.MyEnemy.CurrentHealth}
        Damage : {myGame.MyDefaultPlayer.Damage}";
                string[] options = { option1, option2, option3 };
                Menu mainMenu = new Menu(prompt, options, prompt2);
                int selectedIndex = mainMenu.Run();
                MainSelect(selectedIndex);
                //int selectedOption = selectedIndex + (int)MenuEnums.Options;
            }while (myGame.MyDefaultPlayer.CurrentHealth > 0 && myGame.MyEnemy.CurrentHealth > 0);

            void MainSelect(int selectedIndex)
            {

                switch (selectedIndex)
                {

                    case (int)MenuOptions.attack:
                       {
                            option1 = "BasicAttack";
                            option2 = "HeavyAttack";
                            option3 = " ";
                            AttackSelect(selectedIndex);
                       }
                        break;
                    case (int)MenuOptions.defend:
                            {
                              prompt2 = (prompt2 + "\nYou defend against your opponents attacks");
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
            void AttackSelect(int selectedIndex)
            {
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
                    default:
                        break;

                }
            }                                   

        }
        
        
    }
}
