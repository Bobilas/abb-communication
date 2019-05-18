using Po.Forms.Logging;
using System;
using System.Windows.Forms;
using static ABBControlUnit.ControlUnit;

namespace ABB_Comunication
{
    public partial class MainForm : Form
    {
        public static Logger Logger = new Logger();

        public MainForm()
        {
            InitializeComponent();
            Logger.SetDefaults(this, TextBox_Log);
            InitNetworkWatcher();
        }

        private void Button_Connection_Click(object sender, EventArgs e)
        {
            if ((bool)(Button_Connection.Tag ?? false))
            {
                _controlUnit?.Dispose();
                UpdateButtons(false);
            }
            else
            {
                InitControlUnit();
                UpdateButtons(_controlUnit.TryConnect());
            }
        }

        private void Button_Scan_Click(object sender, EventArgs e) => ReloadControllers();

        private void Button_Rapid_Click(object sender, EventArgs e)
        {
            if ((bool)(Button_Rapid.Tag ?? false))
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
            Invoke((MethodInvoker)delegate
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
            });
        }

        private void Button_MoveByOffset_Click(object sender, EventArgs e)
        {
            _controlUnit?.OffsetMove((double)NumericBox_OffsetX.Value, (double)NumericBox_OffsetY.Value, (double)NumericBox_OffsetZ.Value);
        }
        private void Button_MoveToPosition_Click(object sender, EventArgs e)
        {
            _controlUnit?.Move((double)NumericBox_PositionX.Value, (double)NumericBox_PositionY.Value, (double)NumericBox_PositionZ.Value);
        }
        private void Button_Circle_Click(object sender, EventArgs e)
        {
            _controlUnit?.Circle(_plane, (double)NumericBox_CircleRadius.Value);
        }

        private DrawPlane _plane
        {
            get
            {
                return RadioButton_XY.Checked
                    ? DrawPlane.XY
                    : RadioButton_XZ.Checked
                        ? DrawPlane.XZ
                        : DrawPlane.YZ;
            }
        }

        private void UpdateButtons(bool connected)
        {
            if (connected)
            {
                Button_Connection.Text = "Disconnect";
            }
            else
            {
                Button_Connection.Text = "Connect";
            }
            Button_Connection.Tag = connected;
            Button_Rapid.Enabled = connected;
            Button_Scan.Enabled = !connected;
        }

        private void DataGrid_Controllers_SelectionChanged(object sender, EventArgs e)
        {
            Button_Connection.Enabled =
                (_controlUnit?.IsConnected ?? false)
                || DataGrid_Controllers.SelectedRows.Count == 1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadControllers();
        }
    }
}
