using Login_;
namespace Config_
{
    public class ConfigFile
    {
        public List<LoginConfig> Logins { get; set; }

        public ConfigFile()
        {
            Logins = new List<LoginConfig>();
        }
    }
}
