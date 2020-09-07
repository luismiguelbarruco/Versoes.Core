namespace Versoes.Core.Domain.Services
{
    public interface ICryptographyService
    {
        string Encrypt(string password);
        string Decrypt(string password);
    }
}
