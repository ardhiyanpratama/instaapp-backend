using instaapp_backend.Core.IConfiguration;
using instaapp_backend.Core.IRepositories;
using instaapp_backend.Core.Repositories;
using instaapp_backend.Models;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace instaapp_backend.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly InstaContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(InstaContext context, ILoggerFactory logger, IPasswordHasher<User> passwordHasher, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            Users = new UserRepository(context, _logger, passwordHasher);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
