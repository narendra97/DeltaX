using System.Collections.Generic;

namespace imdb.Model
{
    public class MovieListModel
    {
        public IEnumerable<MovieModel> Movies { get; set; }
    }
}