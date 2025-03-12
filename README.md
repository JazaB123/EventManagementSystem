# Event Management System

Welcome to the Event Management System! This application allows you to create, list, update, and delete events. The system is designed to manage events by storing their details such as name, description, date, and location.

## Features

- **Create**: Allows the user to create a new event by entering details like name, description, date, and location.
- **List**: Lists all the events that have been created.
- **Get**: Retrieves the details of an event using its unique ID.
- **Update**: Allows the user to update an event's details.
- **Delete**: Allows the user to delete an event from the list.

## Prerequisites

To run this project, ensure you have the following installed on your system:

- .NET SDK (for running the application)

## How to Run the Program

1. **Clone the repository**:
   - If you haven't already, clone the repository using:
     ```bash
     git clone <repository-url>
     ```

2. **Open the project folder**:
   - Navigate to the folder where your project is located.
   
3. **Run the application**:
   - Open a terminal in the project directory and run the following command:
     ```bash
     dotnet run
     ```

   The application will start, and you'll be able to interact with the system via the console.

## Available Commands

When the program is running, you can use the following commands to manage events:

- **create**: Create a new event. The program will prompt you to enter the event's name, description, date, and location.
- **list**: Display a list of all events with their ID, name, date, and location.
- **get**: Retrieve the details of a specific event by providing its unique ID.
- **update**: Update an existing event's details (name, description, date, or location).
- **delete**: Delete an event by its ID. The program will ask you to confirm before deletion.
- **exit**: Exit the program.

### Detailed Command Flow

1. **Create an event**:
   - Type the following command to start creating an event:
     ```
     > create
     ```
     The program will prompt you to enter:
     - Event Name
     - Description (optional)
     - Date (yyyy-MM-dd)
     - Location (optional)

2. **List all events**:
   - Type the following command to see a list of all created events:
     ```
     > list
     ```

3. **Get event details**:
   - Type the following command to retrieve an event's details:
     ```
     > get
     ```
     After typing `get`, the program will ask you to **enter the event ID**:
     ```
     Enter Event ID: <event-id>
     ```

4. **Update an event**:
   - Type the following command to update an event:
     ```
     > update
     ```
     After typing `update`, you will be prompted to **enter the event ID**:
     ```
     Enter Event ID to update: <event-id>
     ```
     Once you provide the event ID, the program will ask you for new values for the event's:
     - Name (optional)
     - Description (optional)
     - Date (optional)
     - Location (optional)

5. **Delete an event**:
   - Type the following command to delete an event:
     ```
     > delete
     ```
     After typing `delete`, you will be prompted to **enter the event ID**:
     ```
     Enter Event ID to delete: <event-id>
     ```
     The program will show the details of the event and ask you for confirmation:
     ```
     Are you sure you want to delete this event? (yes/no): <yes/no>
     ```

## Code Overview

The main logic is contained in the `Program.cs` file, which uses a simple in-memory list to store events. Each event has an ID, name, description, date, and location. The application interacts with the user through the console.

### Event Class

The `Event` class defines the structure of an event and contains the following properties:
- `Id`: The unique identifier of the event.
- `Name`: The name of the event.
- `Description`: A description of the event (optional).
- `Date`: The date of the event.
- `Location`: The location of the event (optional).