using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C4_Repo;

namespace C4Program
{
    class C4_Program
    {
        static void Main(string[] args)
            {
            C4ProgramUI ui = new C4ProgramUI();
            ui.Run();
        }

        public class C4ProgramUI
        {
            public List<C4_Outings> myOutings = new List<C4_Outings>();
            public C4Repo repo = new C4Repo();
            public void Run()
            {
                SeedContent();
                Menu();
            }

            private void SeedContent()
            {
                C4_Outings One = new C4_Outings(
                     EventType.Golf,
                    56,
                    DateTime.Now,
                    4999.95
                );
                C4_Outings Two = new C4_Outings(
                     EventType.Golf,
                    42,
                    DateTime.Now,
                    4242.42
                );
                C4_Outings Three = new C4_Outings(
                     EventType.Concert,
                    56,
                    DateTime.Now,
                    4747.47
                );
                C4_Outings Four = new C4_Outings(
                    EventType.Concert,
                   39,
                   DateTime.Now,
                   3939.39
               );
                C4_Outings Five = new C4_Outings(
                     EventType.Bowling,
                    11,
                    DateTime.Now,
                    1111.11
                );
                C4_Outings Six = new C4_Outings(
                   EventType.Bowling,
                   22,
                   DateTime.Now,
                   2222.22
               );
                C4_Outings Seven = new C4_Outings(
                     EventType.Amusement_Park,
                    11,
                    DateTime.Now,
                    3333.33
                );
                C4_Outings Eight = new C4_Outings(
                   EventType.Amusement_Park,
                   22,
                   DateTime.Now,
                   4444.44
               );

                repo.AddEventToList(One);
                repo.AddEventToList(Two);
                repo.AddEventToList(Three);
                repo.AddEventToList(Four);
                repo.AddEventToList(Five);
                repo.AddEventToList(Six);
                repo.AddEventToList(Seven);
                repo.AddEventToList(Eight);
            }

            private void Menu()
            {
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();

                    Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                        "1. Show all Outings\n" +
                        "2. Add new outing\n" +
                        "3. Show total cost of all events\n" +
                        "4. Show Costs by Event Type\n" +
                        "5. Remove outing\n" +
                        "6. Exit");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            // Show all content
                            ShowOutings();
                            break;
                        case "2":
                            //Create new outing
                            AddNewEvent();
                            break;
                        case "3":
                            //Show Toital Cost of All Events
                            ShowCostForAllEvents();
                            break;
                            case "4":
                            // cost by event type
                            ShowCostsByEventType();
                                break;
                         case "5":
                            // Delete existing content
                            Console.WriteLine("this Functionality has not been implimented");
                                 break;
                             default:
                                 Console.WriteLine("Please choose a valid option");
                                 Console.ReadKey();
                                 break;
                    }
                }
            }
            public void ShowOuting(C4_Outings outing)
            {
                Console.WriteLine($"Event Type: {outing.EventType}");
                Console.WriteLine($"Number Attended: {outing.NumberAttended}");
                Console.WriteLine($"Date of Event: {outing.DateOfEvent}");
                Console.WriteLine($"Total Event Cost: {outing.TotalEventCost}");
                Console.WriteLine($"Total Cost Per Person: {outing.TotalCostPerPerson}");
            }
            public void ShowOutings()
            {
                Console.Clear();
                List<C4_Outings> listOfOutings = repo.GetOutings();
                foreach (C4_Outings outing in listOfOutings)
                {
                    ShowOuting(outing);
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            private void AddNewEvent()
            {
                C4_Outings newOuting = new C4_Outings();
                Console.Clear();
                Console.WriteLine("Enter the number of the event type you would like to add:\n" +
                       "1. Golf\n" +
                       "2. Concert\n" +
                       "3. Bowling\n" +
                       "4. Amusement Park\n");
                string eventType = Console.ReadLine();
                bool stopRunning = false;
                while (!stopRunning)
                {
                    switch (eventType)
                    {
                        case "1":
                            newOuting.EventType = EventType.Golf;
                            stopRunning = true;
                            break;
                        case "2":
                            newOuting.EventType = EventType.Concert;
                            stopRunning = true;
                            break;
                        case "3":
                            newOuting.EventType = EventType.Bowling;
                            stopRunning = true;
                            break;
                        case "4":
                            newOuting.EventType = EventType.Amusement_Park;
                            stopRunning = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            stopRunning = false;
                            break;
                    }
                }
                Console.WriteLine("Please enter th number of people that attended the event.");
                newOuting.NumberAttended = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter date of event in format MM/DD/YYYY: ");
                newOuting.DateOfEvent = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the Total cost of the event.");
                newOuting.TotalEventCost = double.Parse(Console.ReadLine());

                bool wasAdded = repo.AddEventToList(newOuting);
                if (wasAdded == true)
                {
                    Console.WriteLine("Your content was succesfully added.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong. Your content was not added.");
                }
            }
            private void ShowCostForAllEvents()
            {
                double CostForAllEvents = 0;
                Console.Clear();
                List<C4_Outings> listOfOutings = repo.GetOutings();
                foreach (C4_Outings outing in listOfOutings)
                {
                    CostForAllEvents += outing.TotalEventCost;
                }
                Console.WriteLine("the total cost for All events is $" + CostForAllEvents);
                Console.ReadKey();
            }
            private void ShowCostsByEventType()
            {
                double CostForEventType = 0;
                List<C4_Outings> listOfOutings = repo.GetOutings();
                Console.Clear();
                Console.WriteLine("Enter the number of the event type you would like to see total costs for:\n" +
                       "1. Golf\n" +
                       "2. Concert\n" +
                       "3. Bowling\n" +
                       "4. Amusement Park\n");
                string eventType = Console.ReadLine();
                bool stopRunning = false;
                while (!stopRunning)
                {
                    switch (eventType)
                    {
                        case "1":
                            foreach (C4_Outings outing in listOfOutings)
                            {
                                if(outing.EventType == EventType.Golf)
                                {
                                CostForEventType += outing.TotalEventCost;
                                }
                            }
                            stopRunning = true;
                          break;
                        case "2":
                            foreach (C4_Outings outing in listOfOutings)
                            {
                                if (outing.EventType == EventType.Concert) {
                                CostForEventType += outing.TotalEventCost;
                            }
                            }
                            stopRunning = true;
                            break;
                         case "3":
                             foreach (C4_Outings outing in listOfOutings)
                            {
                                if (outing.EventType == EventType.Bowling) { 
                                    CostForEventType += outing.TotalEventCost;
                                }
                            }
                            break;
                        case "4":
                            foreach (C4_Outings outing in listOfOutings)
                            {
                                if (outing.EventType == EventType.Amusement_Park) { 
                                CostForEventType += outing.TotalEventCost;
                            }
                            }
                            stopRunning = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            stopRunning = false;
                            break;
                    }
                }
                Console.WriteLine("The total cost for this event type is $" + CostForEventType);
                Console.ReadKey();
            }
        }
    }
}

