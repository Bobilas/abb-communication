using System;
using ABB.Robotics.Controllers;

namespace ABB_Comunication.Control
{
    public partial class ControlUnit : IDisposable
    {
        public ControllerInfo ControllerInfo = null;
        private Controller _controller = null;

        public ControlUnit(ControllerInfo controllerInfo)
        {
            ControllerInfo = controllerInfo ?? throw new Exception("controllerInfo parameter cannot be null.");
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
