using System;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using Forms.Logging;

namespace ABB_Comunication
{
    public partial class ControlUnit
    {
        public bool TrySquare(decimal sideLength) => TrySquare((double)sideLength);
        public bool TrySquare(double sideLength)
        {
            var task = _controller.Rapid.GetTask(RapidNames.TaskName);
            var side = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.SideLength);
            var flag = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.SquareFlag);

            var sideNum = (Num)side.Value;
            var fBool = (Bool)flag.Value;

            if (fBool.Value)
            {
                return TrySquare(sideLength);
            }

            sideNum.Value = sideLength;
            fBool.Value = true;

            try
            {
                if (_controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    using (var m = Mastership.Request(_controller.Rapid))
                    {
                        flag.Value = fBool;
                        side.Value = sideNum;
                    }

                    Logger.InvokeLog($"Drawing square. Side length: {sideLength}");
                    return true;
                }
                else
                {
                    Logger.InvokeLog("Failed to draw a square: Automatic mode is required to start execution from a remote client.");
                }
            }
            catch (InvalidOperationException)
            {
                Logger.InvokeLog("Failed to draw a square: Mastership is held by another client.");
            }
            catch (Exception ex)
            {
                Logger.InvokeLog("Failed to draw a square: " + ex.Message);
            }

            return false;
        }
    }
}
