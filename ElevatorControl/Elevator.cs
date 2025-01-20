namespace ElevatorControl
{
    public class Elevator
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; set; }
        public ElevatorCategory Category { get; private set; }
        private Queue<int> FloorQueue { get; set; }

        public Elevator(int id, int initialFloor, ElevatorCategory category)
        {
            Id = id;
            CurrentFloor = initialFloor;
            Category = category;
            FloorQueue = new Queue<int>();
            Console.WriteLine($"Elevator {Id} initialized at Floor {initialFloor}, Category: {category}.");
        }

        // Add a floor to the elevator's queue
        public void AddFloorToQueue(int floor)
        {
            if (!FloorQueue.Contains(floor))
            {
                FloorQueue.Enqueue(floor);
                Console.WriteLine($"Elevator {Id}: Floor {floor} added to the queue.");
            }
        }

        // Process the next floor in the queue
        public void ProcessNextFloor()
        {
            if (FloorQueue.Count > 0)
            {
                int nextFloor = FloorQueue.Dequeue();
                Console.WriteLine($"Elevator {Id} is moving from Floor {CurrentFloor} to Floor {nextFloor}...");
                CurrentFloor = nextFloor;
                Console.WriteLine($"Elevator {Id} arrived at Floor {CurrentFloor}.");
            }
            else
            {
                Console.WriteLine($"Elevator {Id} has no floors in the queue to process.");
            }
        }

        // Check if the elevator is idle
        public bool IsIdle => FloorQueue.Count == 0;
    }
}
