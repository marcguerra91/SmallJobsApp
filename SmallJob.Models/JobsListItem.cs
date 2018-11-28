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
        public int JobId { get; set; }

        public string TitleOfJob { get; set; }

        [Display(Name="Created Job")]
        public DateTimeOffset CreatedUtc { get; set; }

        public int Pay { get; set; }

        public override string ToString() => TitleOfJob;
    }
}
