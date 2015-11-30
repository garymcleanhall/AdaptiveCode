
namespace TestOverspecification.Services
{
    public interface ILoginService
    {
        bool CheckCredentials(string username, string password);
    }
}
