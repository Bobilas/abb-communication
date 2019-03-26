using System.Diagnostics;

namespace ABB_Comunication.Control
{
    public partial class ControlUnit
    {
        private Stopwatch _timeoutWatch = new Stopwatch();

        private bool HasTimedOut()
        {
            _timeoutWatch.Start();
            if (_timeoutWatch.ElapsedMilliseconds > 5000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void StopTimeout()
        {
            _timeoutWatch.Reset();
        }
    }
}
