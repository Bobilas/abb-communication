using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using Forms.Logging;
using System;

namespace ABB_Comunication
{
    public partial class ControlUnit
    {
        private class RapidNames
        {
            public const string ModuleName = "naujas";
            public const string TaskName = "T_ROB1";
            public class VariableNames
            {
                public const string
                    X = "X1",
                    Y = "Y1",
                    Z = "Z1",
                    SideLength = "size",
                    MoveFlag = "flagas2",
                    SquareFlag = "flagas";
            }
        }

        public bool TryStartRapidProgram()
        {
            try
            {
                var task = _controller.Rapid.GetTask(RapidNames.TaskName);

                if (_controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    using (var mastership = Mastership.Request(_controller.Rapid))
                    {
                        _controller.Rapid.Stop();
                        var pos = new ProgramPosition("MainModule", "main", new TextRange(23));
                        task?.SetProgramPointer(pos);
                        _controller.Rapid.Start(RegainMode.Continue, ExecutionMode.Continuous);
                    }

                    Logger.InvokeLog("Started RAPID program");
                    return true;
                }
                else
                {
                    Logger.InvokeLog("Failed to start rapid program: Setting the program pointer is not allowed in manual mode from a remote client.");
                }
            }
            catch (InvalidOperationException)
            {
                Logger.InvokeLog("Failed to start rapid program: Mastership is held by another client.");
            }
            catch (Exception ex)
            {
                Logger.InvokeLog($"Failed to start rapid program: {ex.Message}");
            }

            return false;
        }
        public bool TryStopRapidProgram()
        {
            try
            {
                if (_controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    using (var mastership = Mastership.Request(_controller.Rapid))
                    {
                        _controller.Rapid.Stop();
                    }

                    Logger.InvokeLog("Stopped RAPID program");
                    return true;
                }
                else
                {
                    Logger.InvokeLog("Failed to stop rapid program: Automatic mode is required to start execution from a remote client.");
                }
            }
            catch (InvalidOperationException)
            {
                Logger.InvokeLog("Failed to stop rapid program: Mastership is held by another client.");
            }
            catch (Exception ex)
            {
                Logger.InvokeLog("Failed to stop rapid program: " + ex.Message);
            }

            return false;
        }
    }
}
