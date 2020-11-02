using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Repo
{
    public class C4Repo
    {
        public List<C4_Outings> outings = new List<C4_Outings>();
        public void AddEventToList() { }
        public bool AddEventToList(C4_Outings newItem)
        {
            int startingCount = outings.Count;
            outings.Add(newItem);
            bool wasAdded = (outings.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool DeleteExistingOuting(C4_Outings existingOuting)
        {
            bool deleteResult = outings.Remove(existingOuting);
            return deleteResult;
        }
        public List<C4_Outings> GetOutings()
        {
            return outings;
        }
    }
}
