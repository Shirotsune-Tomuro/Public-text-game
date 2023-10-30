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
        
        public enum Attacks
        {
            BasicAttack,
            HeavyAttack            
        }
        public void BasicAttack()
        {            
            myGame.MyEnemy.CurrentHealth -= Damage;
        }
        public void HeavyAttack()
        {
            myGame.MyEnemy.CurrentHealth -= Damage;
            CurrentHealth -= myGame.MyEnemy.Damage / 2;
        }      

    }
}
