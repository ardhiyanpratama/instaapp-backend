using instaapp_backend.Core.IRepositories;
using instaapp_backend.Models;
using Microsoft.AspNetCore.Identity;

namespace instaapp_backend.Core.Repositories
{
    public class PostingRepository : GenericRepository<Posting>, IPostingRepository
    {
        public PostingRepository(InstaContext instaContext, ILogger logger) : base(instaContext, logger)
        {

        }

        public override async Task<bool> AddAsync(Posting entity)
        {
            try
            {
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
    }
}
