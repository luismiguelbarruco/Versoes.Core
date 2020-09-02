namespace Versoes.Core.Domain.Services
{
    public interface ICryptention
    {
        string Encrypt(string password);
        string Decrypt(string password);
    }
}
