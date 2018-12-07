using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class JobsListItem
    {
        [Display(Name ="Job ID")]
        public int JobId { get; set; }

        [Display(Name ="Title of job")]
        public string TitleOfJob { get; set; }

        [Display(Name="Created job")]
        public DateTimeOffset CreatedUtc { get; set; }

        public int Pay { get; set; }

        public override string ToString() => TitleOfJob;
    }
}
