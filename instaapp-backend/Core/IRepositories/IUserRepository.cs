using instaapp_backend.Models;

namespace instaapp_backend.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
