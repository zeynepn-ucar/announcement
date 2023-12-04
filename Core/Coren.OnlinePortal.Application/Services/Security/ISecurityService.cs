namespace Coren.OnlinePortal.Application.Services.Security
{
    public interface ISecurityService
    {
        string ComputeHash(string password, int iteration);
    }
}
