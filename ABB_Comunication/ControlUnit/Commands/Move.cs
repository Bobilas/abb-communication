using System;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using Forms.Logging;
using Utilities;

namespace ABB_Comunication
{
    public partial class ControlUnit
    {
        public class Position
        {
            public Position()
            {
                X = 0;
                Y = 0;
                Z = 0;
            }
            public Position(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public double
                X,
                Y,
                Z;

            public bool IsValid => 
                !double.IsNaN(X)
                && !double.IsNaN(Y)
                && !double.IsNaN(Z);
        }

        private class PositionData
        {
            public RapidData X = null;
            public RapidData Y = null;
            public RapidData Z = null;
        }

        public bool TryMove(double x, double y, double z, bool doLog = true) => TryMove(new Position(x, y, z), doLog);
        public bool TryMove(decimal x, decimal y, decimal z, bool doLog = true) => TryMove(new Position((double)x, (double)y, (double)z), doLog);
        public bool TryMove(Position targetPosition, bool doLog = true)
        {
            var task = _controller.Rapid.GetTask(RapidNames.TaskName);
            var positionData = new PositionData()
            {
                X = task.GetRapidData(RapidNames.ModuleName, RapidNames.VariableNames.X),
                Y = task.GetRapidData(RapidNames.ModuleName, RapidNames.VariableNames.Y),
                Z = task.GetRapidData(RapidNames.ModuleName, RapidNames.VariableNames.Z),
            };
            var executeFlag = task.GetRapidData(RapidNames.ModuleName, RapidNames.VariableNames.MoveFlag);

            var xNum = (Num)positionData.X.Value;
            var yNum = (Num)positionData.Y.Value;
            var zNum = (Num)positionData.Z.Value;
            var executeBool = (Bool)executeFlag.Value;

            if (executeBool.Value)
            {
                return TryMove(targetPosition, doLog);
            }

            xNum.Value = targetPosition.X;
            yNum.Value = targetPosition.Y;
            zNum.Value = targetPosition.Z;
            executeBool.Value = true;

            try
            {
                if (_controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    using (var m = Mastership.Request(_controller.Rapid))
                    {
                        positionData.X.Value = xNum;
                        positionData.Y.Value = yNum;
                        positionData.Z.Value = zNum;
                        executeFlag.Value = executeBool;
                    }

                    if (doLog)
                    {
                        Logger.InvokeLog(
                            $"Moving by offset: " +
                            $"{xNum.Value.GetFixedString(3, 2)}; " +
                            $"{yNum.Value.GetFixedString(3, 2)}; " +
                            $"{zNum.Value.GetFixedString(3, 2)}");
                    }

                    return true;
                }
                else
                {
                    Logger.InvokeLog("Failed to move to target position: Automatic mode is required to start execution from a remote client.");
                }
            }
            catch (InvalidOperationException)
            {
                Logger.InvokeLog("Failed to move to target position: Mastership is held by another client.");
            }
            catch (Exception ex)
            {
                Logger.InvokeLog("Failed to move to target position: " + ex.Message);
            }

            return false;
        }
    }
}
