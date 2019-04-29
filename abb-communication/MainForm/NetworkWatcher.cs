using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABB_Comunication
{
    public partial class MainForm
    {
        private NetworkWatcher _networkWatcher = null;
        private NetworkScanner _networkScanner = null;

        void InitNetworkWatcher()
        {
            Task.Run(() =>
            {
                _networkScanner = new NetworkScanner();
                _networkWatcher = new NetworkWatcher(_networkScanner.Controllers);
                _networkWatcher.Found += new EventHandler<NetworkWatcherEventArgs>((o, e) => Invoke((MethodInvoker)delegate
                {
                    AddNewController(e.Controller);
                }));
                _networkWatcher.Lost += new EventHandler<NetworkWatcherEventArgs>((o, e) => Invoke((MethodInvoker)delegate
                {
                    RemoveLostController(e.Controller);
                }));
                _networkWatcher.EnableRaisingEvents = true;
            });
        }

        private const int watcherPaddingRight = 24;
        private void RemoveLostController(ControllerInfo controllerInfo)
        {
            Logger.InvokeLog($"Lost  @{controllerInfo.IPAddress} #{controllerInfo.Id}");
            DataGrid_Controllers.Rows.RemoveAt(getIndex());
            if (_controlUnit?.ControllerInfo.Equals(controllerInfo) ?? false)
            {
                _controlUnit?.Dispose();
                Invoke((MethodInvoker)delegate
                {
                    UpdateButtons(false);
                });
            }

            int getIndex()
            {
                var rows = DataGrid_Controllers.Rows;
                for (int i = 0; i < rows.Count; i++)
                {
                    var tagInfo = (ControllerInfo)rows[i].Tag;
                    if (tagInfo.Equals(controllerInfo))
                    {
                        return i;
                    }
                }
                return -1;
            }
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
            Logger.InvokeLog($"Found @{controllerInfo.IPAddress} #{controllerInfo.Id}");
            DataGrid_Controllers.Rows[DataGrid_Controllers.Rows.Count - 1].Tag = controllerInfo;
        }

        private bool _reloadingControllers = false;
        private void ReloadControllers()
        {
            if (!_reloadingControllers)
            {
                _reloadingControllers = true;
                Invoke((MethodInvoker)delegate
                {
                    Button_Scan.Enabled = false;
                });
                Task.Run(() =>
                {
                    while (_networkScanner == null)
                    {
                        Thread.Sleep(10);
                    }

                    _networkScanner.Scan();
                    Invoke((MethodInvoker)delegate
                    {
                        DataGrid_Controllers.Rows.Clear();

                        foreach (ControllerInfo controllerInfo in _networkScanner.Controllers)
                        {
                            AddNewController(controllerInfo);
                        }
                        if (_networkScanner.Controllers.Count == 0)
                        {
                            Logger.InvokeLog("No controllers were found on the network.");
                        }

                        _reloadingControllers = false;
                        Button_Scan.Enabled = true;
                    });
                });
            }
        }
    }
}
