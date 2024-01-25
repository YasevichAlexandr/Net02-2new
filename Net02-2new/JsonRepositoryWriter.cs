using System.Text.Json;
using Writer_;
using Config_;

namespace JSONReader_
{
    public class JsonRepositoryWriter : IRepositoryWriter
    {
        private readonly string _jsonDirectoryPath;

        public JsonRepositoryWriter(string jsonDirectoryPath)
        {
            _jsonDirectoryPath = jsonDirectoryPath;
        }

        public void WriteConfig(string login, ConfigFile config)
        {
            string jsonFilePath = Path.Combine(_jsonDirectoryPath, login, "config.json");

            Directory.CreateDirectory(Path.GetDirectoryName(jsonFilePath));

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonData = JsonSerializer.Serialize(config, jsonOptions);
            File.WriteAllText(jsonFilePath, jsonData);
        }
    }
}
