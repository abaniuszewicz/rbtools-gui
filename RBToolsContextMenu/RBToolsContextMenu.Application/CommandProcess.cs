using System;
using System.Diagnostics;
using RBToolsContextMenu.Application.Communication.Events;

namespace RBToolsContextMenu.Application
{
    internal class CommandProcess : IDisposable
    {
        private Process _process;

        public event EventHandler<MessageEventArgs> MessageSent;
        public event EventHandler<MessageEventArgs> MessageReceived; 
        
        public CommandProcess()
        {
            InitializeCmdProcess();
            WireMessageEvents();
        }

        private void InitializeCmdProcess()
        {
            _process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                },
                EnableRaisingEvents = true,
            };
        }

        private void WireMessageEvents()
        {
            _process.OutputDataReceived += (s, e) 
                => MessageReceived?.Invoke(this, e.Data);
            _process.ErrorDataReceived += (s, e) 
                => MessageReceived?.Invoke(this, e.Data);
            _process.Exited += (s, e) 
                => MessageReceived?.Invoke(this, "Command process exited.");
            _process.Disposed += (s, e) 
                => MessageReceived?.Invoke(this, "Command process disposed.");
        }

        public void Send(string message)
        {
            MessageSent?.Invoke(this, message);
            _process.StandardInput.WriteLineAsync(message);
        }

        public void Dispose()
        {
            _process?.Dispose();
        }
    }
}