using Newtonsoft.Json;
using RBToolsContextMenu.UI.Wpf.ViewModels;
using System.IO;

namespace RBToolsContextMenu.UI.Wpf.Settings
{
    public static class SettingsLoader
    {
        public static SendViewModel LoadSendViewModel()
        {
            var path = "settings.json";
            var content = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<SendViewModel>(content);
        }
    }
}
