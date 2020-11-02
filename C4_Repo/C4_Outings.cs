using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Repo
{
    public class C4_Outings
    {
        public EventType EventType { get; set; }
        public int NumberAttended { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double TotalCostPerPerson { get { return TotalEventCost / NumberAttended; } }
        public double TotalEventCost { get; set; }
        public C4_Outings() { }

        public C4_Outings(EventType eventType, int numberAttended, DateTime dateOfEvent, double totalEventCost)
        {
            EventType = eventType;
            NumberAttended = numberAttended;
            DateOfEvent = dateOfEvent;
            TotalEventCost = totalEventCost;
        }
    }
    public enum EventType
    {
        Golf,
        Bowling,
        Amusement_Park,
        Concert
    }
}
