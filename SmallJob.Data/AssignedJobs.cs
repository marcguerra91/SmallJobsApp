using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Data
{
    public class AssignedJobs
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public int JobId { get; set; }

        public string TitleOfJob { get; set; }

        [Required]
        public int WorkerId { get; set; }

        [Required]
        public bool JobComplete { get; set; }

        public bool EquipmentAvailable { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual JobsAvailable Jobs { get; set; }

        public Guid OwnerId { get; set; }
        public object FullName { get; set; }
    }
}
