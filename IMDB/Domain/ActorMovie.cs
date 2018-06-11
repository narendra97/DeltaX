using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imdb.Domain
{
    public class ActorMovie : BaseEntity
    {
        public int? ActorId { get; set; }

        public virtual Actor Actor { get; set; }

        public int? MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
