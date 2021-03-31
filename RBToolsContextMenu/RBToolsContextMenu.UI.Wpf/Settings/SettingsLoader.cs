using Newtonsoft.Json;
using RBToolsContextMenu.UI.Wpf.ViewModels;
using System.IO;

namespace RBToolsContextMenu.UI.Wpf.Settings
{
    public static class SettingsLoader
    {
        public static SendViewModel LoadSendViewModel()
        {
            string path = "settings.json";
            string content = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<SendViewModel>(content);
        }
    }
}
