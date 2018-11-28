using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Data
{
    public class JobsAvailable
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string TitleOfJob { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Pay { get; set; }

        [Required]
        public bool EquipmentAvailable { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
