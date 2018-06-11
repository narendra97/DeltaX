using imdb.Domain;

namespace imdb.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(IMDBDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}