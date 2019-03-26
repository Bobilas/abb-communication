using System;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using static ABB_Comunication.MainForm;

namespace ABB_Comunication.Control
{
    public partial class ControlUnit
    {
        public event EventHandler Disconnected;
        public event EventHandler Connected;
        public event EventHandler<ExecutionStatusChangedEventArgs> ExecutionStatusChanged;

        public bool IsConnected => _controller?.Connected ?? false;

        public bool TryConnect() => TryConnect(out _);
        public bool TryConnect(out string exceptionMessage)
        {
            exceptionMessage = null;

            try
            {
                if (ControllerInfo.Availability == Availability.Available)
                {
                    if (IsConnected)
                    {
                        Disconnect(false);
                    }
                    _controller = ControllerFactory.CreateFrom(ControllerInfo);
                    _controller.Logon(UserInfo.DefaultUser);
                    if (IsConnected)
                    {
                        _controller.Rapid.ExecutionStatusChanged += ExecutionStatusChanged;
                        Logger.InvokeLog($"Connected to controller.");
                    }
                    else
                    {
                        Logger.InvokeLog($"Failed to connect to controller.");
                        Disconnect(false);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.InvokeLog($"Failed to connect to controller: {ex.Message}");
                Disconnect(false);
                return false;
            }

            // Checks if controller is in correct mode
            try
            {
                if (_controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    using (var mastership = Mastership.Request(_controller.Rapid)) { }
                    TryStopRapidProgram(false);
                }
                else
                {
                    Logger.InvokeLog("Automatic mode is required to start execution from a remote client.");
                    Disconnect();
                }
            }
            catch (InvalidOperationException ex)
            {
                Logger.InvokeLog($"Mastership is held by another client: {ex.Message}");
                Disconnect();
            }
            catch (Exception ex)
            {
                Logger.InvokeLog($"Unexpected exception occurred when checking controller operating mode: {ex.Message}");
                Disconnect();
            }

            return IsConnected;
        }

        public void Disconnect(bool appendLog = true)
        {
            if (_controller != null)
            {
                try
                {
                    _controller.Logoff();
                    _controller.Dispose();
                    _controller = null;
                }
                catch (Exception ex)
                {
                    Logger.InvokeLog($"An exception occured when disconnecting from controller {ControllerInfo.ControllerName}: {ex.Message}");
                }
            }

            if (appendLog)
            {
                Logger.InvokeLog($"Disconnected from controller {ControllerInfo.ControllerName}.");
            }
        }
    }
}
