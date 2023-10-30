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
    class DefaultEnemy : ParentCharacter
    {
        public DefaultEnemy(Game Game) : base(Game)
        {            
            Description = "You the player";            
            Level = 1;
            Armour = 0;
            StrengthStat = 5;            
            DexterityStat = 10;
            ManaStat = 10;
            HealthStat = 15;
            Damage = (int)(StrengthStat * Level * 0.9);
            MaxHealth = (int)(HealthStat * Level * 1.5);
            CurrentHealth = MaxHealth;    
                                   
        }
        public override void Run()
        {
            CombatPanel();
        }
        private static void CombatPanel()
        {
         
        }
        
        public void RandomShenanigan()
        {
            if (CurrentHealth >= Level)
            {
                CurrentHealth = CurrentHealth - 1;
            }
        }

    }
}
