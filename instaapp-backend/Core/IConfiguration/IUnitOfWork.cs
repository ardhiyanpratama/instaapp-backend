namespace instaapp_backend.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
