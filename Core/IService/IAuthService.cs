namespace Core.IService
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string senha);
    }
}