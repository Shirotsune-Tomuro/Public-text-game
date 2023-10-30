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
            StartCombat();
        }

        private void StartCombat()
        { 
            string? prompt2 = default;

            do
            {

            string prompt = $@"You have engaged in combat

Current Health : {myGame.MyDefaultPlayer.CurrentHealth}     Enemy Health :   {myGame.MyEnemy.CurrentHealth}
        Damage : {myGame.MyDefaultPlayer.Damage}";                           
            string[] options = { "attack", "defend", "flee" };
            Menu mainMenu = new Menu(prompt, options, prompt2);            
            int selectedIndex = mainMenu.Run();            
           
                switch (selectedIndex)
                {

                    case 0:
                        {
                            prompt2 = (prompt2 + "\nYou strike at the enemy with your equipped weapon");
                            myGame.MyEnemy.CurrentHealth -= myGame.MyDefaultPlayer.Damage;
                        }
                        break;
                    case 1:
                        prompt2 = (prompt2 + "\nYou defend against your opponents attacks");
                        break;
                    case 2:
                        prompt2 = (prompt2 + "\nYou Attempt to flee");
                        break;                    
                }
            } while (myGame.MyDefaultPlayer.CurrentHealth > 0 && myGame.MyEnemy.CurrentHealth > 0);
            Clear();         

        }
        
        
    }
}
