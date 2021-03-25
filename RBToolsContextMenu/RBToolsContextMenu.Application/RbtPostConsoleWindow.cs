using System;

namespace RBToolsContextMenu.Application
{
    public class RbtPostConsoleWindow : IDisposable
    {
        private readonly RbtPostProcess _rbtPostProcess;
        
        public event EventHandler<string> OnMessageSent;
        public event EventHandler<string> OnMessageReceived;
        public event EventHandler<string> OnError;
        public event EventHandler OnExit; 

        public RbtPostConsoleWindow()
        {
            _rbtPostProcess = new RbtPostProcess();
            _rbtPostProcess.OutputDataReceived += (o, e) => OnMessageReceived?.Invoke(this, e.Data);
            _rbtPostProcess.ErrorDataReceived += (o, e) => OnError?.Invoke(this, e.Data);
            _rbtPostProcess.Exited += (o, e) => OnExit?.Invoke(this, EventArgs.Empty);
            _rbtPostProcess.Start();
        }

        public void Execute(string command)
        {
            OnMessageSent?.Invoke(this, command);
            _rbtPostProcess.StandardInput.WriteLine(command);
        }

        public void Dispose()
        {
            _rbtPostProcess.Close();
            _rbtPostProcess?.Dispose();
        }
    }
}