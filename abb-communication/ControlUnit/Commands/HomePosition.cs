using System;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using Forms.Logging;
using Utilities;

namespace ABB_Comunication
{
    public partial class ControlUnit
    {
        public bool TryHome(bool doLog = true)
        {
            var task = _controller.Rapid.GetTask(RapidNames.TaskName);

            var executeFlag = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.ExecuteFlag);
            if (executeFlag.GetBool())
            {
                return TryHome(doLog);
            }

            return TryMove(DrawPlane.XY, 0.0, 0, 0, false);
        }
    }
}
