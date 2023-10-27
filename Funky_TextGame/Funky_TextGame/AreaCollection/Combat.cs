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
            do
            {                
                WriteLine("Current Health : " + myGame.MyDefaultPlayer.Health);
                SetCursorPosition(40, 0);
                WriteLine("Enemy Health : " + myGame.MyEnemy.Health);
                WriteLine("\n");
                string prompt = "Welcome to Funky Text Game, What would you like to do?\n";
                string[] options = { "attack", "defend", "flee" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();

            } while (myGame.MyDefaultPlayer.Health > 0 || myGame.MyEnemy.Health > 0);
        }
        
        
    }
}
