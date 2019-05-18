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
        public (double x, double y, double z) GetPosition()
        {
            var task = _controller.Rapid.GetTask(RapidNames.TaskName);

            var xData = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.XCoord);
            var yData = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.YCoord);
            var zData = task.GetRapidData(RapidNames.ModuleName, RapidNames.Variables.ZCoord);

            return (xData.GetDouble(), yData.GetDouble(), zData.GetDouble());
        }
    }
}
