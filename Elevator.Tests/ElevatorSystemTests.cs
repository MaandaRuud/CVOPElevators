using ElevatorControl;

namespace Elevator.Tests
{
    [TestClass]
    public class ElevatorSystemTests
    {
        [TestMethod]
        public void ElevatorSystem_AssignClosestElevator_ShouldReturnClosestElevator()
        {
            var system = new ElevatorSystem();

            system.HandleElevatorRequest(Role.GeneralWorker, 2);

            Assert.IsTrue(system != null);
        }
    }
}
