using imdb.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imdb.Domain
{
    public class Movie : BaseEntity
    {
        public int? ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public int?  ActorId {get;set;}

        public virtual Actor Actor { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime YearOfReleased { get; set; }

        [Required]
        public string Plot { get; set; }

    }
}