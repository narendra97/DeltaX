using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace imdb.Model
{
    public class MovieModel
    {
        public int Id { get; set; }

        public int ProducerId { get; set; }

        public int ActorId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime YearOfReleased { get; set; }

        [Required]
        public string Plot { get; set; }   

    }
}