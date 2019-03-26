using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using ABB_Comunication.Control;

namespace ABB_Comunication
{
    public partial class MainForm
    {
        private ControlUnit _controlUnit = null;

        private void InitControlUnit()
        {
            _controlUnit?.Dispose();
            var controllerInfo = (ControllerInfo)DataGrid_Controllers.SelectedRows[0].Tag;
            _controlUnit = new ControlUnit(controllerInfo);
            _controlUnit.ExecutionStatusChanged += ControlUnit_ExecutionStatusChanged;
        }

        private void ControlUnit_ExecutionStatusChanged(object sender, ExecutionStatusChangedEventArgs e)
        {
            UpdateRapidButton(e.Status == ExecutionStatus.Running);
        }
    }
}
