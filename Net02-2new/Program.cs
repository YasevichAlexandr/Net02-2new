using Writer_;
using Reader_;
using JSONReader_;
using XMLReader_;
using Layer_;

class Program
{
    static void Main(string[] args)
    {
        string xmlFilePath = @"C:\Users\User\source\repos\Net02-2new\Net02-2new\Config.xml";
        string jsonDirectoryPath = @"C:\Users\User\source\repos\Net02-2new\Net02-2new\Config";

        IRepositoryReader repositoryReader = new XmlRepositoryReader(xmlFilePath);
        IRepositoryWriter repositoryWriter = new JsonRepositoryWriter(jsonDirectoryPath);

        DataAccessLayer dataAccessLayer = new DataAccessLayer(repositoryReader, repositoryWriter);

        Console.WriteLine("Reading and printing config:");
        dataAccessLayer.ReadAndPrintConfig();

        Console.WriteLine("Checking and migrating config:");
        dataAccessLayer.CheckAndMigrateConfig();

        Console.WriteLine("Config migration completed.");

        Console.ReadLine();
    }
}