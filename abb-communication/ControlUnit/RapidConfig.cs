using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using Forms.Logging;
using System;

namespace ABB_Comunication
{
    public partial class ControlUnit
    {
        private struct RapidNames
        {
            public const string ModuleName = "MoveModule";
            public const string ProcName = "MoveModule_main";
            public const string TaskName = "T_ROB1";
            public struct Variables
            {
                public const string
                    XCoord = "xCoord",
                    YCoord = "yCoord",
                    ZCoord = "zCoord",
                    XOffset = "xOffset",
                    YOffset = "yOffset",
                    ZOffset = "zOffset",
                    ExecuteFlag = "executeFlag",
                    HomeFlag = "homeFlag";
            }
        }

        public bool TryStartRapidProgram()
        {
            try
            {
                if (_controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    var task = _controller.Rapid.GetTask(RapidNames.TaskName);
                    if (task.ExecutionStatus == TaskExecutionStatus.Running)
                    {
                        Logger.InvokeLog("RAPID program is already running.");
                        return true;
                    }
                    using (var mastership = Mastership.Request(_controller.Rapid))
                    {
                        task?.SetProgramPointer(RapidNames.ModuleName, RapidNames.ProcName);
                        _controller.Rapid.Start(RegainMode.Continue, ExecutionMode.Continuous);
                    }

                    Logger.InvokeLog("Started RAPID program");
                    return true;
                }
                else
                {
                    Logger.InvokeLog("Cannot start RAPID program: Controller operating mode must be set to automatic.");
                }
            }
            catch (InvalidOperationException)
            {
                Logger.InvokeLog("Failed to start RAPID program: Mastership is held by another client.");
            }
            catch (Exception ex)
            {
                Logger.InvokeLog($"Failed to start RAPID program: {ex.Message}");
            }

            return false;
        }
        public bool TryStopRapidProgram(bool doLog = true)
        {
            try
            {
                if (_controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    var task = _controller.Rapid.GetTask(RapidNames.TaskName);
                    using (var mastership = Mastership.Request(_controller.Rapid))
                    {
                        _controller.Rapid.Stop(StopMode.Immediate);
                    }

                    if (doLog)
                    {
                        Logger.InvokeLog("Stopped RAPID program");
                    }
                    return true;
                }
                else
                {
                    if (doLog)
                    {
                        Logger.InvokeLog("Failed to stop RAPID program: Controller operating mode must be set to automatic.");
                    }
                }
            }
            catch (InvalidOperationException)
            {
                if (doLog)
                {
                    Logger.InvokeLog("Failed to stop RAPID program: Mastership is held by another client.");
                }
            }
            catch (Exception ex)
            {
                if (doLog)
                {
                    Logger.InvokeLog("Failed to stop RAPID program: " + ex.Message);
                }
            }

            return false;
        }
    }
}
