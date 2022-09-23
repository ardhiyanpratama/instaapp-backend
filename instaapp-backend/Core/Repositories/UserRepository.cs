using instaapp_backend.Core.IRepositories;
using instaapp_backend.Data;
using instaapp_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace instaapp_backend.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserRepository(InstaContext instaContext, ILogger logger, IPasswordHasher<User> passwordHasher) : base (instaContext, logger)
        {
            _passwordHasher = passwordHasher;
        }
        public override async Task<bool> AddAsync(User entity)
        {
            try
            {
                entity.Password = _passwordHasher.HashPassword(entity, entity.Password);

                entity.CreatedAt = DateTime.UtcNow;
                entity.UpdatedAt = DateTime.UtcNow;

                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await dbSet.FirstOrDefaultAsync(e => e.Username == username);
            if (user is null)
            {
                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.Password = _passwordHasher.HashPassword(user, password);

                dbSet.Update(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }
    }
}
