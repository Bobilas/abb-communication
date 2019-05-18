using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using RapidTask = ABB.Robotics.Controllers.RapidDomain.Task;

namespace ABBControlUnit
{
    public partial class ControlUnit : IDisposable
    {
        public ControllerInfo ControllerInfo = null;
        private Controller _controller = null;

        public ControlUnit(ControllerInfo controllerInfo)
        {
            ControllerInfo = controllerInfo ?? throw new Exception($"{nameof(controllerInfo)} parameter cannot be null.");
        }

        #region DRAW PLANE ENUM

        public enum DrawPlane
        {
            XY,
            YZ,
            XZ
        }

        #endregion

        #region AWAIT COMPLETION

        private bool AwaitCompletion()
        {
            RapidTask task;
            RapidData executeFlag;

            do
            {
                if (HasTimedOut())
                {
                    StopTimeout();
                    OnMessageCall($"Operation has timed out.");
                    return false;
                }
                task = _controller.Rapid.GetTask(RapidNames.TaskName);
                executeFlag = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.ExecuteFlag);
                Thread.Sleep(1);
            } while (!executeFlag.GetBool());

            StopTimeout();
            return true;
        }


        /// <summary>
        /// Command timeout in miliseconds. Default value: 5000ms
        /// </summary>
        public long CommandTimeout = 10_000;
        private Stopwatch _timeoutWatch = new Stopwatch();

        private bool HasTimedOut()
        {
            _timeoutWatch.Start();
            if (_timeoutWatch.ElapsedMilliseconds > CommandTimeout)
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

        #endregion

        #region COMMAND ASYNC

        private ulong _asyncQueueLength = 0;
        private ulong _asyncQueuePosition = 0;

        private bool AwaitQueue()
        {
            ulong order = _asyncQueueLength++;
            while (order < _asyncQueuePosition)
            {
                Thread.Sleep(10);
            }
            return order == _asyncQueuePosition;
        }
        private void AdvanceQueue()
        {
            _asyncQueuePosition++;
        }
        private bool CommandAsync(Func<bool> command)
        {
            if (!AwaitQueue())
            {
                return false;
            }
            bool result = command();
            AdvanceQueue();
            return result;
        }

        public void AbortAllCommands()
        {
            _asyncQueuePosition = _asyncQueueLength;
        }

        #endregion

        #region DISPOSE
        public void Dispose()
        {
            Disconnect();
        }

        #endregion
    }
}
