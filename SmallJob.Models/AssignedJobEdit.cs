using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class AssignedJobEdit
    {
        [Display(Name="Assignment ID")]
        public int AssignmentId { get; set; }

        [Display(Name ="Job ID")]
        public int JobId { get; set; }

        [Display(Name ="Title of job")]
        public string TitleOfJob { get; set; }

        [Display(Name ="Worker ID")]
        public int WorkerId { get; set; }

        [Display(Name ="Job Complete")]
        public bool JobComplete { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public object LastName { get; set; }
        public object FirstName { get; set; }
        public string FullName { get; set; }
    }
}
