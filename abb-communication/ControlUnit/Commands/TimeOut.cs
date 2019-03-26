using System;
using System.Diagnostics;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using Forms.Logging;
using Utilities;

namespace ABB_Comunication
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
