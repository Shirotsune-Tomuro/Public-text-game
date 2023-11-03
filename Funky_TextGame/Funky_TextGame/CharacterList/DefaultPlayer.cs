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
            // filling in the variables from the parent class
            Description = "You the player";
            Level = 1;
            Armour = 0;
            StrengthStat = 6;
            DexterityStat = 10;
            ManaStat = 10;
            HealthStat = 10;
            Damage = (int)(StrengthStat * Level);
            MaxHealth = (int)(HealthStat * Level);
            CurrentHealth = MaxHealth;
                        
        }
        public override void Run()
        {            
        }        
       
        public void BasicAttack()
        {            
            myGame.MyEnemy.CurrentHealth -= Damage;
        }
        public void HeavyAttack()
        {
            myGame.MyEnemy.CurrentHealth -= Damage * 2;
            CurrentHealth -= myGame.MyEnemy.Damage / 2;
        }      

    }
}
