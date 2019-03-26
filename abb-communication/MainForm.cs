using System;
using System.Windows.Forms;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.RapidDomain;
using Forms.Logging;
using static ABB_Comunication.ControlUnit;

namespace ABB_Comunication
{
    public partial class MainForm : Form
    {
        private ControlUnit _controlUnit = null;

        private NetworkWatcher _networkWatcher = null;
        private NetworkScanner _networkScanner = new NetworkScanner();

        private EventHandler _connectedHandler;
        private EventHandler _disconnectedHandler;
        private EventHandler<ExecutionStatusChangedEventArgs> _statusChangedHandler;

        public MainForm()
        {
            InitializeComponent();
            Button_Rapid.Tag = false;
            Logger.LogBox = LogBox;
            Logger.Form = this;
            ReloadControllers();
            initNetworkWatcher();
            initConnectionEvents();

            void initNetworkWatcher()
            {
                _networkWatcher = new NetworkWatcher(_networkScanner.Controllers);
                _networkWatcher.Found += new EventHandler<NetworkWatcherEventArgs>((o, e) => Invoke((MethodInvoker)delegate
                {
                    AddNewController(e.Controller);
                }));
                _networkWatcher.Lost += new EventHandler<NetworkWatcherEventArgs>((o, e) => Invoke((MethodInvoker)delegate
                {
                    removeLostController(e.Controller);
                }));
                _networkWatcher.EnableRaisingEvents = true;

                void removeLostController(ControllerInfo controllerInfo)
                {
                    DataGrid_Controllers.Rows.RemoveAt(getIndex());
                    if (_controlUnit?.ControllerInfo == controllerInfo)
                    {
                        _controlUnit?.Dispose();
                    }

                    int getIndex()
                    {
                        var rows = DataGrid_Controllers.Rows;
                        for (int i = 0; i < rows.Count; i++)
                        {
                            if ((ControllerInfo)rows[i].Tag == controllerInfo)
                            {
                                return i;
                            }
                        }
                        return -1;
                    }
                }
            }
            void initConnectionEvents()
            {
                _connectedHandler = new EventHandler((o, e) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        UpdateButtons();
                    });
                });
                _disconnectedHandler = new EventHandler((o, e) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        UpdateButtons();
                    });
                });
                _statusChangedHandler = new EventHandler<ExecutionStatusChangedEventArgs>((o, e) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        UpdateRapidButton(e.Status == ExecutionStatus.Running);
                    });
                });
            }
        }

        public void InvokeInfoMessage(string info)
        {
            try
            {
                if (IsHandleCreated)
                {
                    if (!_isFormClosing)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            AppendLog(info);
                        });
                    }
                }
                else
                {
                    AppendLog(info);
                }
            }
            catch { }
        }
        private void AppendLog(string info) => Logger.Log(info);

        private void ReloadControllers()
        {
            _networkScanner.Scan();
            DataGrid_Controllers.Rows.Clear();

            foreach (ControllerInfo controllerInfo in _networkScanner.Controllers)
            {
                AddNewController(controllerInfo);
            }
            if (_networkScanner.Controllers.Count == 0)
            {
                Logger.Log("No controllers were found on the network.");
            }

            UpdateButtons();
        }

        private void AddNewController(ControllerInfo controllerInfo)
        {
            DataGrid_Controllers.Rows.Add(
                controllerInfo.IPAddress,
                controllerInfo.Id,
                controllerInfo.Availability.ToString(),
                controllerInfo.SystemName,
                controllerInfo.Version.ToString(),
                controllerInfo.ControllerName);
            DataGrid_Controllers.Rows[DataGrid_Controllers.Rows.Count - 1].Tag = controllerInfo;
        }

        private void Button_Connection_Click(object sender, EventArgs e)
        {
            if (Button_Connection.Text == "Connect")
            {
                try
                {
                    _controlUnit?.Dispose();
                    var controllerInfo = (ControllerInfo)DataGrid_Controllers.SelectedRows[0].Tag;
                    _controlUnit = new ControlUnit(controllerInfo, _connectedHandler, _disconnectedHandler, _statusChangedHandler);
                    _controlUnit.TryConnect();
                    _controlUnit.TryStopRapidProgram(false);
                }
                catch (Exception ex)
                {
                    AppendLog($"An exception occured when connecting to controller: {ex.Message}");
                }
            }
            else
            {
                _controlUnit?.Dispose();
            }
        }

        private void Button_Scan_Click(object sender, EventArgs e) => ReloadControllers();

        private void Button_Rapid_Click(object sender, EventArgs e)
        {
            if ((bool)Button_Rapid.Tag)
            {
                _controlUnit?.TryStopRapidProgram();
            }
            else
            {
                _controlUnit?.TryStartRapidProgram();
            }
        }
        private void UpdateRapidButton(bool isRunning)
        {
            Button_Rapid.Tag = isRunning;

            if (isRunning)
            {
                Button_Rapid.Text = "Stop RAPID";
            }
            else
            {
                Button_Rapid.Text = "Start RAPID";
            }
        }

        private void Button_MoveByOffset_Click(object sender, EventArgs e)
        {
            _controlUnit?.TryOffsetMove(GetDrawPlane(), NumericBox_OffsetX.Value, NumericBox_OffsetY.Value, NumericBox_OffsetZ.Value);
        }
        private void Button_MoveToPosition_Click(object sender, EventArgs e)
        {
            _controlUnit?.TryMove(GetDrawPlane(), NumericBox_PositionX.Value, NumericBox_PositionY.Value, NumericBox_PositionZ.Value);
        }
        private void Button_Circle_Click(object sender, EventArgs e)
        {
            _controlUnit?.TryCircle(GetDrawPlane(), NumericBox_CircleRadius.Value);
        }

        private DrawPlane GetDrawPlane()
        {
            return RadioButton_XY.Checked
                ? DrawPlane.XY
                : RadioButton_XZ.Checked
                    ? DrawPlane.XZ
                    : DrawPlane.YZ;
        }

        private void Button_Home_Click(object sender, EventArgs e) => _controlUnit?.TryHome();

        private void UpdateButtons()
        {
            Button_Connection.Text =
                (_controlUnit?.IsConnected ?? false)
                ? "Disconnect" : "Connect";
            Button_Rapid.Enabled = _controlUnit?.IsConnected ?? false;
            Button_Scan.Enabled = !(_controlUnit?.IsConnected ?? false);
        }

        private bool _isFormClosing = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => _isFormClosing = true;

        private void DataGrid_Controllers_SelectionChanged(object sender, EventArgs e)
        {
            Button_Connection.Enabled =
                (_controlUnit?.IsConnected ?? false)
                || DataGrid_Controllers.SelectedRows.Count == 1;
        }
    }
}
