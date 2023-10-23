using Funky_TextGame.AreaCollection;
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
                myGame.MyDefaultPlayer.Run();
            }
            while (myGame.MyDefaultPlayer.Health > 0);
            {
                //do enemy action
            }
        }
        
        
    }
}
