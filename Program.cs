﻿namespace EventManagementSystem
{
    class Program
    {
        private static List<Event> events = new List<Event>();
        private static int nextId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Event Management System!");
            bool running = true;

            while (running)
            {
                Console.Write("> ");
                string? command = Console.ReadLine();

                switch (command?.ToLower())
                {
                    case "create":
                        CreateEvent(); 
                        break;
                    case "list":
                        ListEvents(); 
                        break;
                    case "get":
                        GetEvent(); 
                        break;
                    case "update":
                        UpdateEvent(); 
                        break;
                    case "delete":
                        DeleteEvent(); 
                        break;
                    case "exit":
                        running = false; 
                        break;
                    default:
                        Console.WriteLine("Unknown command"); 
                        break;
                }
            }
        }

        static void CreateEvent()
        {
            string? name;
            while (true) 
            {
                Console.Write("Enter Event Name: ");
                name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Event name cannot be empty. Please enter a name");
                }
            }

            Console.Write("Enter Description (optional): ");
            string? description = Console.ReadLine();

            DateTime date;
            while (true) 
            {
                Console.Write("Enter Date (yyyy-MM-dd): ");
                string? _date = Console.ReadLine();

                if (DateTime.TryParseExact(_date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid. Please enter a date that is in the correct format - yyyy-MM-dd");
                }
            }

            Console.Write("Enter Location (optional): ");
            string? location = Console.ReadLine();

            Event newEvent = new Event
            {
                Id = nextId++, 
                Name = name,
                Description = description,
                Date = date,
                Location = location
            };

            events.Add(newEvent);
            Console.WriteLine("Event created successfully!");
        }

        static void ListEvents()
        {
            if (events.Count == 0)
            {
                Console.WriteLine("No events have been added"); 
            }
            else
            {
                foreach (var e in events)
                {
                    Console.WriteLine($"ID: {e.Id}, Name: {e.Name}, Date: {e.Date.ToShortDateString()}, Location: {e.Location}");
                }
            }
        }

        static void GetEvent()
        {
            Console.Write("Enter Event ID: ");
            string? _id = Console.ReadLine();

            if (int.TryParse(_id, out int id))
            {
                Console.WriteLine($"Valid ID entered: {id}");
            }
            else
            {
                Console.WriteLine("The ID you have entered does not exist. Try again");
            }

            var eventItem = events.Find(e => e.Id == id);
            if (eventItem != null)
            {
                Console.WriteLine($"Name: {eventItem.Name}");
                Console.WriteLine($"Description: {eventItem.Description}");
                Console.WriteLine($"Date: {eventItem.Date.ToShortDateString()}");
                Console.WriteLine($"Location: {eventItem.Location}");
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }

        static void UpdateEvent()
        {
            Console.Write("Enter Event ID to update: ");
            string? _id = Console.ReadLine();

            if (int.TryParse(_id, out int id))
            {
                Console.WriteLine($"Valid ID entered: {id}");
            }
            else
            {
                Console.WriteLine("The ID you have entered does not exist. Try again");
            }

            var eventItem = events.Find(e => e.Id == id);
            if (eventItem != null)
            {
                string? newName = eventItem.Name;
                while (true)
                {
                    Console.Write($"Enter new Name (leave empty to keep current): ");
                    string? _name = Console.ReadLine();


                    if (string.IsNullOrEmpty(_name))
                    {
                        break; 
                    }
                    else
                    {
                        newName = _name;
                        break;
                    }
                }
                eventItem.Name = newName;


                Console.Write($"Enter new Description (leave empty to keep current): ");
                string? newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription)) eventItem.Description = newDescription;


                DateTime? newDate = eventItem.Date;
                while (true)
                {
                    Console.Write($"Enter new Date (leave empty to keep current): ");
                    string? _date = Console.ReadLine();


                    if (string.IsNullOrEmpty(_date))
                    {
                        break;
                    }


                    DateTime date;
                    if (DateTime.TryParseExact(_date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date))
                    {
                        eventItem.Date = date;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid. Please enter a date that is in the correct format - yyyy-MM-dd");
                    }
                }


                Console.Write($"Enter new Location (leave empty to keep current): ");
                string? newLocation = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLocation)) eventItem.Location = newLocation;


                Console.WriteLine("Event updated successfully!");


            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }
        
        static void DeleteEvent()
        {
            Console.Write("Enter Event ID to delete: ");
            string? _id = Console.ReadLine();

            if (int.TryParse(_id, out int id))
            {
                Console.WriteLine($"Valid ID entered: {id}");
            }
            else
            {
                Console.WriteLine("The ID you have entered does not exist. Try again");
            }

            var eventItem = events.Find(e => e.Id == id);
            if (eventItem != null)
            {
                Console.WriteLine("\nEvent details:");
                Console.WriteLine($"Name: {eventItem.Name}");
                Console.WriteLine($"Description: {eventItem.Description}");
                Console.WriteLine($"Date: {eventItem.Date.ToShortDateString()}");
                Console.WriteLine($"Location: {eventItem.Location}");

                Console.Write("Are you sure you want to delete this event? (yes/no): ");
                string? confirm = Console.ReadLine();
                if (confirm?.ToLower() == "yes")
                {
                    events.Remove(eventItem); 
                    Console.WriteLine("Event deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Delete canceled");
                }
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }
    }
}
