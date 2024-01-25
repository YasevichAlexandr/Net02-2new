using Config_;
namespace Writer_
{
    public interface IRepositoryWriter
    {
        void WriteConfig(string login, ConfigFile config);
    }
}
