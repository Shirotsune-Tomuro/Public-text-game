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
        public enum Options
        {
            attack,
            defend,
            flee
        }                 

        public override void Run()
        {
            StartCombat();
        }

        private void StartCombat()
        { 
            string? prompt2 = default;
            string option1 = Options.attack.ToString();          
            string option2 = Options.defend.ToString();          
            string option3 = Options.flee.ToString();          

            do
            {          
            string prompt = $@"You have engaged in combat
Current Health : {myGame.MyDefaultPlayer.CurrentHealth}     Enemy Health :   {myGame.MyEnemy.CurrentHealth}
        Damage : {myGame.MyDefaultPlayer.Damage}";                           
            string[] options = { option1, option2, option3 };          
            Menu mainMenu = new Menu(prompt, options, prompt2);            
            int selectedIndex = mainMenu.Run();            
           
                switch (selectedIndex)
                {

                    case 0:
                        {
                            option1 = DefaultPlayer.Attacks.BasicAttack.ToString();
                            option2 = DefaultPlayer.Attacks.HeavyAttack.ToString();
                            option3 = " ";                            
                        }
                        break;
                    case 1:
                        {
                            prompt2 = (prompt2 + "\nYou defend against your opponents attacks");
                        }
                        break;
                    case 2:
                        {
                            prompt2 = (prompt2 + "\nYou Attempt to flee");
                        }
                        break;                    
                }
            } while (myGame.MyDefaultPlayer.CurrentHealth > 0 && myGame.MyEnemy.CurrentHealth > 0);
            Clear();         

        }
        
        
    }
}
