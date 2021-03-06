﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace imdb.Model
{
	public class ProducerModel
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