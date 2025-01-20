using ElevatorControl;

Console.WriteLine("Welcome to the Elevator Control System!");

// Create elevator system instance
ElevatorSystem elevatorSystem = new ElevatorSystem();

// Display elevator status
elevatorSystem.DisplayElevatorStatus();

// Prompt user for role
Console.WriteLine("\nSelect your role:");
Console.WriteLine("1. Visitor");
Console.WriteLine("2. General Worker");
Console.WriteLine("3. Lower Management");
Console.WriteLine("4. Middle Management");
Console.WriteLine("5. Upper Management");

Role userRole;
int roleSelection;
while (!int.TryParse(Console.ReadLine(), out roleSelection) || roleSelection < 1 || roleSelection > 5)
{
    Console.WriteLine("Invalid selection. Please enter a number between 1 and 5.");
}

userRole = (Role)(roleSelection - 1);

// Prompt user for floor
Console.WriteLine("\nEnter the floor number you want to go to:");
int requestedFloor;
while (!int.TryParse(Console.ReadLine(), out requestedFloor))
{
    Console.WriteLine("Invalid input. Please enter a valid floor number.");
}

// Handle the elevator request
elevatorSystem.HandleElevatorRequest(userRole, requestedFloor);

// Display final elevator status
elevatorSystem.DisplayElevatorStatus();
