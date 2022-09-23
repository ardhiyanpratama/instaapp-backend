using instaapp_backend.Core.IRepositories;

namespace instaapp_backend.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
