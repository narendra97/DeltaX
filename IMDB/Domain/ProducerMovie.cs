using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imdb.Domain
{
    public class ProducerMovie : BaseEntity
    {
        public int? ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public int? MovieId { get; set; }

        public virtual Movie Movie { get; set; }

    }
}
