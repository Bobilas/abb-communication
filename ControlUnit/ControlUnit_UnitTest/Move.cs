using ABB.Robotics.Controllers.Discovery;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBControlUnit.UnitTest
{
    [TestFixture]
    public class ControlUnitTests
    {
        private NetworkScanner _networkScanner = new NetworkScanner();
        private static ControlUnit _controlUnit = null;
        
        private void InitControlUnit()
        {
            _networkScanner.Scan();
            Assert.Greater(_networkScanner.Controllers.Count, 0, "No controller found on the network.");
            _controlUnit = new ControlUnit(_networkScanner.Controllers.First());
            Assert.AreEqual(_controlUnit.TryConnect(), true, "Failed to connect to controller.");
        }

        private const double _maxError = 0.5;
        [Test]
        public void Move()
        {
            // Connection
            InitControlUnit();
            Assert.AreEqual(_controlUnit.TryStartRapidProgram(), true, $"Failed to start RAPID program.");
            // Home position
            Assert.AreEqual(_controlUnit.Move(0, 0, 0), true,
                $"Failed to move to home position.");
            var firstPos = _controlUnit.GetPosition();
            Assert.Less(Math.Abs(firstPos.x), _maxError, "Too high of an error on the X axis. Home position.");
            Assert.Less(Math.Abs(firstPos.y), _maxError, "Too high of an error on the Y axis. Home position.");
            Assert.Less(Math.Abs(firstPos.z), _maxError, "Too high of an error on the Z axis. Home position.");
            // (50, 50, 50) position
            (double x, double y, double z) posOffset = (50, 50, 50);
            Assert.AreEqual(_controlUnit.Move(firstPos.x + posOffset.x, firstPos.y + posOffset.y, firstPos.z + posOffset.z), true, 
                $"Failed to move to specified location.");
            var secondPos = _controlUnit.GetPosition();
            Assert.Less(Math.Abs(secondPos.x - firstPos.x - posOffset.x), _maxError, $"Too high of an error on the X axis. ({posOffset.x}, {posOffset.y}, {posOffset.z}) position.");
            Assert.Less(Math.Abs(secondPos.y - firstPos.y - posOffset.y), _maxError, $"Too high of an error on the Y axis. ({posOffset.x}, {posOffset.y}, {posOffset.z}) position.");
            Assert.Less(Math.Abs(secondPos.z - firstPos.z - posOffset.z), _maxError, $"Too high of an error on the Z axis. ({posOffset.x}, {posOffset.y}, {posOffset.z}) position.");
        }
    }
}
