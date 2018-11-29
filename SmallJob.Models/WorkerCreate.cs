﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class WorkerCreate
    {
        [Required]
        [Key]
        public int WorkerId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string LastName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Email { get; set; }

        public override string ToString() => FirstName;
    }
}
