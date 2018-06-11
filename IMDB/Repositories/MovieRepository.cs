using imdb.Domain;

namespace imdb.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IMDBDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}