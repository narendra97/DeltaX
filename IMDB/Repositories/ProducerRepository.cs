using imdb.Domain;

namespace imdb.Repositories
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(IMDBDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}