using Window_;

namespace Login_
{
    public class LoginConfig
    {
        public string Name { get; set; }
        public Dictionary<string, WindowConfig> Windows { get; set; }

        public LoginConfig()
        {
            Windows = new Dictionary<string, WindowConfig>();
        }

        public LoginConfig(string name) : this()
        {
            Name = name;
        }
    }
}
