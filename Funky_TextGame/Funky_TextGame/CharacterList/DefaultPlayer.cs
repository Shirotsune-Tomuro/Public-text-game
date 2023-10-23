using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Funky_TextGame.CharacterList
{
    class DefaultPlayer : ParentCharacter
    {
        public DefaultPlayer(Game Game) : base(Game)
        {            
            Description = "You the player";
            Strength = 0;
            Mana = 0;
            Health = 0;
            Armour = 0;
            Level = 0;
        }
        public override void Run()
        {
            CombatPanel();
        }
        private static void CombatPanel()
        {
            string prompt = "Combat related stuff\n";
            string[] options = { "Attack", "Defend", "Flee" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
        }
        
        public void RandomShenanigan()
        {
            if (Health >= Level)
            {
                Health = Health - 1;
            }
        }

    }
}
