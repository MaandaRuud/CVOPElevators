using ElevatorControl;

namespace Elevator.Tests
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void Elevator_AddFloorToQueue_ShouldAddFloorToQueue()
        {
            var elevator = new ElevatorControl.Elevator(1, 0, ElevatorCategory.General);

            elevator.AddFloorToQueue(3);

            Assert.IsFalse(elevator.IsIdle);
        }

        [TestMethod]
        public void Elevator_ProcessNextFloor_ShouldMoveToNextFloor()
        {
            var elevator = new ElevatorControl.Elevator(1, 0, ElevatorCategory.General);
            elevator.AddFloorToQueue(3);

            elevator.ProcessNextFloor();

            Assert.AreEqual(3, elevator.CurrentFloor);
        }
    }
}
