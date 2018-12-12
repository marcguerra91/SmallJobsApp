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
        [Display(Name ="Job ID")]
        public int JobId { get; set; }

        [Display(Name ="Owner ID")]
        public int OwnerId { get; set; }

        [Display(Name ="Title of job")]
        public string TitleOfJob { get; set; }

        public string Description { get; set; }

        public int Pay { get; set; }

        [Display(Name ="Equipment Available")]
        public bool EquipmentAvailable { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString() => $"[{JobId}] {TitleOfJob}";
    }
}
