using Mingems.Infrastructure.DbContexts;

namespace Mingems.Infrastructure.Common
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        public readonly MingemsDbContext context;

        public BaseRepository(MingemsDbContext context)
        {
            this.context = context;
        }
    }
}
