using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Funky_TextGame
{    
    public class Area
    {
        public String Name;
        public String Description;
        public Dictionary<string, Area> Exits { get; } = new Dictionary<string, Area>();
    }
    //EnemyPool
    //LootPool
}

