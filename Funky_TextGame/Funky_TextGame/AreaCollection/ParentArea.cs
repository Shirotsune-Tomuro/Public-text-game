using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Funky_TextGame.StartFunctions;

namespace Funky_TextGame.AreaCollection
{

    // this is the parent class for every level
    class Area
    {
        protected Game myGame;

        public String Name = "";
        public String Description = "";  
        protected bool Completed = false;

        //all levels pass throught the game class
        public Area(Game Game)
        {
            myGame = Game;
        }
        //this can be edited per child
        public void Run(int eLevel)
        {
            Start(eLevel);
        }

        virtual protected void Start(int eLevel)
        {
        }
    }
    
}

