using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    class WorkerDetail
    {
        [Required]
        [Key]
        public int WorkerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => $"[{WorkerId}] {FirstName} {LastName} {PhoneNumber} {Email} {CreatedUtc}";
    }
}
