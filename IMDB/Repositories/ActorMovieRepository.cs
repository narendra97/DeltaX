using imdb.Domain;

namespace imdb.Repositories
{
    public class ActorMovieRepository : GenericRepository<ActorMovie>, IActorMovieRepository
    {
        public ActorMovieRepository(IMDBDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
