using System;
using ABB.Robotics.Controllers;

namespace ABB_Comunication
{
    public partial class ControlUnit : IDisposable
    {
        public ControllerInfo ControllerInfo = null;
        private Controller _controller = null;

        public ControlUnit(ControllerInfo controllerInfo, EventHandler connectedHandler, EventHandler disconnectedHandler)
        {
            ControllerInfo = controllerInfo ?? throw new Exception("controllerInfo parameter cannot be null.");
            Connected += connectedHandler;
            Disconnected += disconnectedHandler;
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
