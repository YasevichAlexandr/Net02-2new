using System.Xml.Linq;
using Reader_;
using Window_;
using Login_;
using Config_;

namespace XMLReader_
{
    public class XmlRepositoryReader : IRepositoryReader
    {
        private readonly string _xmlFilePath;

        public XmlRepositoryReader(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;
        }

        public ConfigFile ReadConfig()
        {
            XDocument xmlDoc = XDocument.Load(_xmlFilePath);
            var configElements = xmlDoc.Root.Elements("login");

            ConfigFile configFile = new ConfigFile();
            foreach (var configElement in configElements)
            {
                string loginName = (string)configElement.Attribute("name");
                LoginConfig loginConfig = new LoginConfig(loginName);

                var windowElements = configElement.Elements("window");
                foreach (var windowElement in windowElements)
                {
                    string windowTitle = (string)windowElement.Attribute("title");
                    WindowConfig windowConfig = new WindowConfig
                    {
                        Title = windowTitle,
                        Top = GetValueOrDefault(windowElement.Element("top"), 0),
                        Left = GetValueOrDefault(windowElement.Element("left"), 0),
                        Width = GetValueOrDefault(windowElement.Element("width"), 400),
                        Height = GetValueOrDefault(windowElement.Element("height"), 150)
                    };

                    loginConfig.Windows.Add(windowTitle, windowConfig);
                }

                configFile.Logins.Add(loginConfig);
            }

            return configFile;
        }

        private int GetValueOrDefault(XElement element, int defaultValue)
        {
            if (element != null && int.TryParse(element.Value, out int value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}
