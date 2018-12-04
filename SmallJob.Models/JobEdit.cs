using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class JobEdit
    {
        public int JobId { get; set; }

        public string TitleOfJob { get; set; }

        public string Description { get; set; }

        [Range(10, 200, ErrorMessage = "Pay range is between $10-$200")]
        public int Pay { get; set; }

        public bool EquipmentAvailable { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
