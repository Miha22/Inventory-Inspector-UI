#region Configuration
using Rocket.API;
using System.Collections.Generic;

namespace ItemRestrictorAdvanced
{
    public class PluginConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public string Key;
        public void LoadDefaults()
        {
            Enabled = true;
            Key = "12345";
        }
    }
}
#endregion Configuration
