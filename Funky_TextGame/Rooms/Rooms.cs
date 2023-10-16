using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Funky_TextGame
{
    public class Room
    {
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public Dictionary<string, RoomInstance> Exits { get;} = new Dictionary<string, RoomInstance>();
    }
    public class RoomInstance
    {
        static RoomInstance CurrentRoom;        
        public void Rooms()
        {
            RoomInstance Cave1 = new RoomInstance {RoomName = "Cave 1", RoomDescription = "You are in cave zone 1"}; 
            RoomInstance Cave2 = new RoomInstance {RoomName = "Cave 2", RoomDescription = "You are in cave zone 2"};
        }
    }
}
