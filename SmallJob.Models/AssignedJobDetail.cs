using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class AssignedJobDetail
    {
        public int AssignmentId { get; set; }

        public int JobId { get; set; }

        public string TitleOfJob { get; set; }

        public int WorkerId { get; set; }

        public bool JobComplete { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => $"[{AssignmentId}] {TitleOfJob}";
    }
}
