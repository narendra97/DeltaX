using imdb.Domain;

namespace imdb.Repositories
{
    public class ProducerMovieRepository : GenericRepository<ProducerMovie>, IProducerMovieRepository
    {
        public ProducerMovieRepository(IMDBDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
