using System;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;

namespace ABBControlUnit
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
                        OnMessageCall($"Connected to controller @{ControllerInfo.IPAddress}");
                    }
                    else
                    {
                        OnMessageCall($"Failed to connect to controller.");
                        Disconnect(false);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                OnMessageCall($"Failed to connect to controller: {ex.Message}");
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
                    OnMessageCall("Automatic mode is required to start execution from a remote client.");
                    Disconnect();
                }
            }
            catch (InvalidOperationException ex)
            {
                OnMessageCall($"Mastership is held by another client: {ex.Message}");
                Disconnect();
            }
            catch (Exception ex)
            {
                OnMessageCall($"Unexpected exception occurred when checking controller operating mode: {ex.Message}");
                Disconnect();
            }

            Connected?.Invoke(this, null);
            return IsConnected;
        }

        public void Disconnect(bool appendLog = true)
        {
            if (_controller != null)
            {
                try
                {
                    TryStopRapidProgram(false);
                    _controller.Logoff();
                    _controller.Dispose();
                    _controller = null;
                    Disconnected?.Invoke(this, null);

                    if (appendLog)
                    {
                        OnMessageCall($"Disconnected from controller @{ControllerInfo.IPAddress}");
                    }
                }
                catch (Exception ex)
                {
                    OnMessageCall($"An exception occured when disconnecting from controller @{ControllerInfo.IPAddress}: {ex.Message}");
                }
            }
        }
    }
}
