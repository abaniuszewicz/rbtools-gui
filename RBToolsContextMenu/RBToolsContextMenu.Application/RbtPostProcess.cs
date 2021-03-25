using System.Diagnostics;

namespace RBToolsContextMenu.Application
{
    public class RbtPostProcess : Process
    {
        public RbtPostProcess()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            EnableRaisingEvents = true;
        }
    }
}