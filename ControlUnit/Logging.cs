using System;

namespace ABBControlUnit
{
    public partial class ControlUnit
    {
        public event Action<string> MessageCall;

        private void OnMessageCall(string message)
        {
            MessageCall(message);
        }
    }
}
