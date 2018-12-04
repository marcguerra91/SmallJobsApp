using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class JobDetail
    {
        public int JobId { get; set; }

        public int OwnerId { get; set; }

        public string TitleOfJob { get; set; }

        public string Description { get; set; }

        public int Pay { get; set; }

        public bool EquipmentAvailable { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString() => $"[{JobId}] {TitleOfJob}";
    }
}
