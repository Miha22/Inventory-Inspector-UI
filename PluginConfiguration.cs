#region Configuration
using Rocket.API;


namespace ItemRestrictorAdvanced
{
    public class PluginConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public string LicenseKey;
        public void LoadDefaults()
        {
            Enabled = true;
            LicenseKey = System.Guid.Empty.ToString();
        }
    }
}
#endregion Configuration
