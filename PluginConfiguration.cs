#region Configuration
using Rocket.API;


namespace ItemRestrictorAdvanced
{
    public class afhui4hasdfsui3h3g : IRocketPluginConfiguration
    {
        public bool Enabled;
        public string LicenseKey { get; set; } = System.Guid.Empty.ToString();
        public void LoadDefaults()
        {
            LicenseKey = System.Guid.Empty.ToString();
            Enabled = true;
        }
    }
}
#endregion Configuration
