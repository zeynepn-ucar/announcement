using System.Security.Cryptography;
using System.Text;

namespace Coren.OnlinePortal.Application.Services.Security
{
    public class SecurityService : ISecurityService
    {
        public string ComputeHash(string password, int iteration)
        {
            if (iteration <= 0) return password;
            var byteHash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hash = Convert.ToBase64String(byteHash);
            return ComputeHash(hash, iteration - 1);
        }
    }
}
