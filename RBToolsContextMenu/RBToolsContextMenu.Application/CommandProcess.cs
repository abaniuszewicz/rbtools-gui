using System;
using System.Diagnostics;
using System.Threading;
using RBToolsContextMenu.Application.Communication.Events;

namespace RBToolsContextMenu.Application
{
    internal class CommandProcess : IDisposable
    {
        private static readonly SemaphoreSlim _semaphore = new(1, 1);
        private Process _process;


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

            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
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

        public async void Send(string message)
        {
            await _semaphore.WaitAsync();
            await _process.StandardInput.WriteLineAsync(message);
            _semaphore.Release();
        }

        public void Dispose()
        {
            _process?.Dispose();
        }
    }
}