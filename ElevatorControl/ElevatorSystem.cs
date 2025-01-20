namespace ElevatorControl
{
    public class ElevatorSystem
    {
        private List<Elevator> _elevators;

        public ElevatorSystem()
        {
            // Initialize elevators with categories and initial floors
            _elevators = new List<Elevator>
            {
                new Elevator(1, 0, ElevatorCategory.General), // General use elevator 1
                new Elevator(2, 2, ElevatorCategory.General), // General use elevator 2
                new Elevator(3, 4, ElevatorCategory.General), // General use elevator 3
                new Elevator(4, 0, ElevatorCategory.Visitor), // Visitor elevator
                new Elevator(5, 0, ElevatorCategory.Service)  // Service elevator
            };
            Console.WriteLine("Elevator system initialized with 5 elevators.");
        }

        // Get accessible floors based on the role
        private List<int> GetAccessibleFloors(Role role)
        {
            var floors = new List<int> { 0 }; // Ground floor is always accessible
            switch (role)
            {
                case Role.Visitor:
                    floors.Add(1); // Visitors can only access Floor 1
                    break;
                case Role.GeneralWorker:
                    floors.AddRange(new[] { 1, 2 }); // General Workers: 1 and 2
                    break;
                case Role.LowerManagement:
                    floors.AddRange(new[] { 1, 2, 3 }); // Lower Management: up to 3
                    break;
                case Role.MiddleManagement:
                    floors.AddRange(new[] { 1, 2, 3, 4 }); // Middle Management: up to 4
                    break;
                case Role.UpperManagement:
                    floors.AddRange(new[] { 1, 2, 3, 4 }); // Upper Management: all
                    break;
            }
            Console.WriteLine($"Accessible floors for role {role}: {string.Join(", ", floors)}");
            return floors;
        }

        // Assign the closest idle elevator to the requested floor
        private Elevator AssignClosestElevator(int requestedFloor, ElevatorCategory category)
        {
            var availableElevators = _elevators
                .Where(elevator => elevator.Category == category && elevator.IsIdle)
                .OrderBy(elevator => Math.Abs(elevator.CurrentFloor - requestedFloor))
                .ToList();

            if (availableElevators.Any())
            {
                var closestElevator = availableElevators.First();
                Console.WriteLine($"Closest idle elevator to Floor {requestedFloor} (Category: {category}): Elevator {closestElevator.Id}.");
                return closestElevator;
            }

            Console.WriteLine($"No idle elevators available for Category: {category}.");
            return null;
        }

        // Handle the elevator request
        public void HandleElevatorRequest(Role role, int requestedFloor)
        {
            // Determine elevator category based on role
            ElevatorCategory category = role == Role.Visitor ? ElevatorCategory.Visitor :
                                         role == Role.GeneralWorker ? ElevatorCategory.General :
                                         role == Role.UpperManagement ? ElevatorCategory.General :
                                         ElevatorCategory.Service;

            Console.WriteLine($"Handling request for Role: {role}, Requested Floor: {requestedFloor}, Elevator Category: {category}.");

            // Assign an elevator
            Elevator assignedElevator = AssignClosestElevator(requestedFloor, category);

            if (assignedElevator != null)
            {
                Console.WriteLine($"\nElevator {assignedElevator.Id} assigned for Floor {requestedFloor}.");
                assignedElevator.AddFloorToQueue(requestedFloor);
                assignedElevator.ProcessNextFloor();
            }
            else
            {
                Console.WriteLine("\nNo available elevators at the moment. Please wait...");
            }
        }

        // Display the current status of all elevators
        public void DisplayElevatorStatus()
        {
            Console.WriteLine("\nCurrent Elevator Status:");
            foreach (var elevator in _elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id}: Floor {elevator.CurrentFloor}, Category {elevator.Category}, Idle: {elevator.IsIdle}");
            }
        }
    }
}
