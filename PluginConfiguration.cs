#region Configuration
using Rocket.API;
using System;

namespace ItemRestrictorAdvanced
{
    public class PluginConfiguration : IRocketPluginConfiguration
    {
        public string LicenseKey;
        public void LoadDefaults()
        {
            LicenseKey = Guid.Empty.ToString();
        }
    }
}
#endregion Configuration
