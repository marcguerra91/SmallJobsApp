using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Data
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string LastName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Email { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = FirstName + " " + LastName; }
        }


        public DateTimeOffset CreatedUtc { get; set; }
    }
}
