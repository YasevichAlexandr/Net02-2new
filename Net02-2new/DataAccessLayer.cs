using Writer_;
using Reader_;
using Window_;
using Login_;
using Config_;

namespace Layer_
{
    public class DataAccessLayer
    {
        private readonly IRepositoryReader _repositoryReader;
        private readonly IRepositoryWriter _repositoryWriter;

        public DataAccessLayer(IRepositoryReader repositoryReader, IRepositoryWriter repositoryWriter)
        {
            _repositoryReader = repositoryReader;
            _repositoryWriter = repositoryWriter;
        }

        public void ReadAndPrintConfig()
        {
            ConfigFile configFile = _repositoryReader.ReadConfig();

            foreach (var loginConfig in configFile.Logins)
            {
                Console.WriteLine($"Login: {loginConfig.Name}");
                foreach (var windowConfig in loginConfig.Windows.Values)
                {
                    Console.WriteLine($"  {windowConfig.Title}({windowConfig.Top}, {windowConfig.Left}, {windowConfig.Width}, {windowConfig.Height})");
                }
            }
        }

        public void CheckAndMigrateConfig()
        {
            ConfigFile configFile = _repositoryReader.ReadConfig();

            foreach (var loginConfig in configFile.Logins)
            {
                if (!IsConfigValid(loginConfig))
                {
                    Console.WriteLine($"Invalid configuration for login: {loginConfig.Name}");

                    foreach (var windowConfig in loginConfig.Windows.Values)
                    {
                        if (windowConfig.Top == 0)
                            windowConfig.Top = 0;
                        if (windowConfig.Left == 0)
                            windowConfig.Left = 0;
                        if (windowConfig.Width == 0)
                            windowConfig.Width = 400;
                        if (windowConfig.Height == 0)
                            windowConfig.Height = 150;
                    }
                }

                _repositoryWriter.WriteConfig(loginConfig.Name, configFile);
            }
        }

        private bool IsConfigValid(LoginConfig loginConfig)
        {
            bool hasMainWindow = loginConfig.Windows.ContainsKey("main");
            if (hasMainWindow)
            {
                WindowConfig mainWindow = loginConfig.Windows["main"];
                return mainWindow.Top != 0 && mainWindow.Left != 0 && mainWindow.Width != 0 && mainWindow.Height != 0;
            }

            return true;
        }
    }
}
