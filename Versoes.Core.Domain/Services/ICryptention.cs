namespace Versoes.Core.Domain.Services
{
    public interface ICryptography
    {
        string Encrypt(string password);
        string Decrypt(string password);
    }
}
