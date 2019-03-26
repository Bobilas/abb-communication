using System;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;

namespace ABB_Comunication
{
    public partial class ControlUnit : IDisposable
    {
        public ControllerInfo ControllerInfo = null;
        private Controller _controller = null;

        public ControlUnit(
            ControllerInfo controllerInfo, 
            EventHandler connectedHandler, 
            EventHandler disconnectedHandler, 
            EventHandler<ExecutionStatusChangedEventArgs> statusChangedHandler)
        {
            ControllerInfo = controllerInfo ?? throw new Exception("controllerInfo parameter cannot be null.");
            Connected += connectedHandler;
            Disconnected += disconnectedHandler;
            ExecutionStatusChanged += statusChangedHandler;
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
