using System;
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
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        public int PhoneNumber { get; set; }


        public override string ToString() => FirstName;
    }
}
