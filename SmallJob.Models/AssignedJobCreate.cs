using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class AssignedJobsCreate
    {
        [Display(Name ="Assignment ID")]
        public int AssignmentId { get; set; }

        [Display(Name ="Job ID")]
        public int JobId { get; set; }

        [Display(Name ="Title of job")]
        public string TitleOfJob { get; set; }

        [Display(Name ="Worker assigned ID")]
        public int WorkerId { get; set; }

        [Display(Name ="Equipment Available")]
        public bool EquipmentAvailable { get; set; }

        public override string ToString() => TitleOfJob;
    }
}
