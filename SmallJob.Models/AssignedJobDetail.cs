using SmallJob.Data;
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
        [Display(Name ="Assignment ID:")]
        public int AssignmentId { get; set; }

        [Display(Name ="Job ID:")]
        public int JobId { get; set; }

        [Display(Name ="Title of job:")]
        public string TitleOfJob { get; set; }

        [Display(Name ="Worker assigned ID:")]
        public int WorkerId { get; set; }

        [Display(Name ="Job complete:")]
        public bool JobComplete { get; set; }

        [Display(Name ="Equipment Available:")]
        public bool EquipmentAvailable { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name="Created:")]
        public DateTimeOffset CreatedUtc { get; set; }

        public virtual Worker Worker { get; set; }


        public override string ToString() => $"[{AssignmentId}] {TitleOfJob}";
    }
}
