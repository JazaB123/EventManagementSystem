namespace EventManagementSystem
{
    class Program
    {
        // A list that will hold all created events
        private static List<Event> events = new List<Event>();
        // A variable to assign unique IDs to each event
        private static int nextId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Event Management System!");
            bool running = true; // Set running to true when user enters program

            while (running)
            {
                Console.Write("> ");
                string? command = Console.ReadLine();

                switch (command?.ToLower()) //Switch statement to handle the different commands
                {
                    case "create":
                        CreateEvent(); // Calls CreateEvent Method when user enters "create"
                        break;
                    case "list":
                        ListEvents(); // Calls ListEvents Method when user enters "list"
                        break;
                    case "get":
                        GetEvent(); // Calls GetEvent Method when user enters "get"
                        break;
                    case "update":
                        UpdateEvent(); // Calls UpdateEvent when user enters "update"
                        break;
                    case "delete":
                        DeleteEvent(); // Calls DeleteEvent when user enters "delete"
                        break;
                    case "exit":
                        running = false; // Set running to false when user enters "exit" and exits the program
                        break;
                    default:
                        Console.WriteLine("Unknown command"); // Message if the command is not recognized
                        break;
                }
            }
        }

        static void CreateEvent()
        {
            string? name;
            while (true) // Ensures the event name is not empty
            {
                Console.Write("Enter Event Name: ");
                name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name))
                {
                    break; // Exit loop if a name is entered
                }
                else
                {
                    Console.WriteLine("Event name cannot be empty. Please enter a name");
                }
            }

            Console.Write("Enter Description (optional): ");
            string? description = Console.ReadLine();

            DateTime date;
            while (true) // Ensures the date is in the correct format and not empty
            {
                Console.Write("Enter Date (yyyy-MM-dd): ");
                string? _date = Console.ReadLine();

                // Try to parse the date in yyyy-MM-dd format
                if (DateTime.TryParseExact(_date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    break; // Exit loop if a valid date is entered
                }
                else
                {
                    Console.WriteLine("Invalid. Please enter a date that is in the correct format - yyyy-MM-dd");
                }
            }

            Console.Write("Enter Location (optional): ");
            string? location = Console.ReadLine();

            // Create new event and add to list
            Event newEvent = new Event
            {
                Id = nextId++, // Assigns next available ID
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
            // Check if an event exists in the list
            if (events.Count == 0)
            {
                Console.WriteLine("No events have been added"); // if no events exist return this message
            }
            else
            {
                foreach (var e in events) // Display all events in the list
                {
                    Console.WriteLine($"ID: {e.Id}, Name: {e.Name}, Date: {e.Date.ToShortDateString()}, Location: {e.Location}");
                }
            }
        }

        static void GetEvent()
        {
            Console.Write("Enter Event ID: ");
            string? _id = Console.ReadLine();

            // Try to parse the string Id entered by the user into an int
            if (int.TryParse(_id, out int id))
            {
                Console.WriteLine($"Valid ID entered: {id}");
            }
            else
            {
                Console.WriteLine("The ID you have entered does not exist. Try again");
            }

            // Find event using the ID
            var eventItem = events.Find(e => e.Id == id);
            if (eventItem != null)
            {
                // Display event details
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


            // Try to parse the string Id entered by the user into an int
            if (int.TryParse(_id, out int id))
            {
                Console.WriteLine($"Valid ID entered: {id}");
            }
            else
            {
                Console.WriteLine("The ID you have entered does not exist. Try again");
            }


            // Find the event by its ID
            var eventItem = events.Find(e => e.Id == id);
            if (eventItem != null)
            {
                // Update event name
                string? newName = eventItem.Name;
                while (true)
                {
                    Console.Write($"Enter new Name (leave empty to keep current): ");
                    string? _name = Console.ReadLine();


                    if (string.IsNullOrEmpty(_name))
                    {
                        break; // Exit loop if no new name is entered
                    }
                    else
                    {
                        newName = _name; // Save new name
                        break;
                    }
                }
                eventItem.Name = newName;


                Console.Write($"Enter new Description (leave empty to keep current): ");
                string? newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription)) eventItem.Description = newDescription;


                DateTime? newDate = eventItem.Date;
                while (true) // Ensure the new date is valid format (leave empty to keep current)
                {
                    Console.Write($"Enter new Date (leave empty to keep current): ");
                    string? _date = Console.ReadLine();


                    if (string.IsNullOrEmpty(_date))
                    {
                        break; // Exit loop if no new date is entered
                    }


                    DateTime date;
                    if (DateTime.TryParseExact(_date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date))
                    {
                        eventItem.Date = date; // Update date if date is in valid format
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

            // Try to parse the string Id entered by the user into an int
            if (int.TryParse(_id, out int id))
            {
                Console.WriteLine($"Valid ID entered: {id}");
            }
            else
            {
                Console.WriteLine("The ID you have entered does not exist. Try again");
            }

            // Find the event by ID and remove it
            var eventItem = events.Find(e => e.Id == id);
            if (eventItem != null)
            {
                // Ask user to confirm delete
                Console.WriteLine("\nEvent details:");
                Console.WriteLine($"Name: {eventItem.Name}");
                Console.WriteLine($"Description: {eventItem.Description}");
                Console.WriteLine($"Date: {eventItem.Date.ToShortDateString()}");
                Console.WriteLine($"Location: {eventItem.Location}");

                Console.Write("Are you sure you want to delete this event? (yes/no): ");
                string? confirm = Console.ReadLine();
                if (confirm?.ToLower() == "yes")
                {
                    events.Remove(eventItem); // remove from the list
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
