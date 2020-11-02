using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Repo
{
    class C3_Properties
    {
        public string BadgeID { get; set; }

        public string BadgeIDtoDoors { get; set; }

        
        public C3BadgesToDoors(string badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            doors = Doors;
           
        }
        private Dictionary<string, C3_Properties.Doors> BadgestoDoors = new Dictionary<string, List<string>>();
    }
}
