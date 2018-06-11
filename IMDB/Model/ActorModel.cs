using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imdb.Model
{
    public class ActorModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string BIO { get; set; }
        
    }
}