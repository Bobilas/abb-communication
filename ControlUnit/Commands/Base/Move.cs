using System;
using System.Threading.Tasks;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using Po.Utilities;
using Task = System.Threading.Tasks.Task;
using RapidTask = ABB.Robotics.Controllers.RapidDomain.Task;

namespace ABBControlUnit
{
    public partial class ControlUnit
    {
        public Task<bool> MoveAsync(double x, double y, double z, bool doLog = true)
        {
            return Task.FromResult(CommandAsync(new Func<bool>(() => Move(x, y, z, doLog))));
        }

        public bool Move(double x, double y, double z, bool doLog = true)
        {
            return MoveDetailed(x, y, z, doLog).result;
        }

        private (bool result, double x, double y, double z) MoveDetailed(double x, double y, double z, bool doLog = true)
        {
            if (!AwaitCompletion())
            {
                return (false, 0, 0, 0);
            }

            var task = _controller.Rapid.GetTask(RapidNames.TaskName);

            var executeFlag = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.ExecuteFlag);
            var homeFlag = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.HomeFlag);
            var xData = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.XOffset);
            var yData = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.YOffset);
            var zData = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.ZOffset);

            try
            {
                if (_controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    using (var m = Mastership.Request(_controller.Rapid))
                    {
                        xData.Value = new Num(x);
                        yData.Value = new Num(y);
                        zData.Value = new Num(z);
                        homeFlag.Value = new Bool(true);
                        executeFlag.Value = new Bool(true);
                    }

                    if (doLog)
                    {
                        OnMessageCall(
                            $"Moving to position: " +
                            $"{x.GetFixedString(3, 2)}; " +
                            $"{y.GetFixedString(3, 2)}; " +
                            $"{z.GetFixedString(3, 2)}");
                    }

                    var position = GetPosition();
                    return (AwaitCompletion(), position.x, position.y, position.z);
                }
                else
                {
                    OnMessageCall("Failed to move to target position: Automatic mode is required to start execution from a remote client.");
                }
            }
            catch (InvalidOperationException)
            {
                OnMessageCall("Failed to move to target position: Mastership is held by another client.");
            }
            catch (Exception ex)
            {
                OnMessageCall("Failed to move to target position: " + ex.Message);
            }

            return (false, 0, 0, 0);
        }
    }
}
