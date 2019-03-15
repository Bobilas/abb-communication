using System;
using System.Windows.Forms;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using Forms.Logging;

namespace ABB_Comunication
{
    public partial class MainForm : Form
    {
        private ControlUnit _controlUnit = null;

        private NetworkWatcher _networkWatcher = null;
        private NetworkScanner _networkScanner = new NetworkScanner();

        private EventHandler _connectedHandler;
        private EventHandler _disconnectedHandler;

        public MainForm()
        {
            InitializeComponent();
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
                    _controlUnit = new ControlUnit(controllerInfo, _connectedHandler, _disconnectedHandler);
                    _controlUnit.TryConnect();
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

        private void Button_StartRapid_Click(object sender, EventArgs e) => _controlUnit?.TryStartRapidProgram();
        private void Button_StopRapid_Click(object sender, EventArgs e) => _controlUnit?.TryStopRapidProgram();

        private void Button_Move_Click(object sender, EventArgs e) => _controlUnit?.TryMove(NumericBox_X.Value, NumericBox_Y.Value, NumericBox_Z.Value);
        private void Button_Square_Click(object sender, EventArgs e) => _controlUnit?.TrySquare(NumericBox_SquareSide.Value);
        private void Button_Circle_Click(object sender, EventArgs e) => _controlUnit?.TryCircle(NumericBox_CircleRadius.Value);

        private void NumericBox_SquareSide_ValueChanged(object sender, EventArgs e) => UpdateSquareButton();
        private void NumericBox_X_ValueChanged(object sender, EventArgs e) => UpdateMoveButton();
        private void NumericBox_Y_ValueChanged(object sender, EventArgs e) => UpdateMoveButton();
        private void NumericBox_Z_ValueChanged(object sender, EventArgs e) => UpdateMoveButton();
        private void NumericBox_CircleRadius_ValueChanged(object sender, EventArgs e) => UpdateCircleButton();

        private void UpdateButtons()
        {
            Button_Connection.Text =
                (_controlUnit?.IsConnected ?? false)
                ? "Disconnect" : "Connect";
            Button_StartRapid.Enabled = _controlUnit?.IsConnected ?? false;
            Button_StopRapid.Enabled = _controlUnit?.IsConnected ?? false;
            Button_Scan.Enabled = !(_controlUnit?.IsConnected ?? false);
            UpdateMoveButton();
            UpdateSquareButton();
            UpdateCircleButton();
        }
        private void UpdateMoveButton() => Button_Move.Enabled = _controlUnit?.IsConnected ?? false;
        private void UpdateSquareButton() => Button_Square.Enabled = _controlUnit?.IsConnected ?? false;
        private void UpdateCircleButton() => Button_Circle.Enabled = _controlUnit?.IsConnected ?? false;

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
