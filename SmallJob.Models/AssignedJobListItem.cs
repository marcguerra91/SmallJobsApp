﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallJob.Data;

namespace SmallJob.Models
{
    public class AssignedJobListItem
    {
        [Display(Name ="Assignment ID:")]
        public int AssignmentId { get; set; }

        [Display(Name ="Job ID:")]
        public int JobId { get; set; }

        [Display(Name ="Title Of Job:")]
        public string TitleOfJob { get; set; }

        [Display(Name ="Worker Assigned ID:")]
        public int WorkerId { get; set; }

        [Display(Name ="Job Complete")]
        public bool JobComplete { get; set; }

        [Display(Name="In progress since:")]
        public DateTimeOffset CreatedUtc { get; set; }

        public Worker Worker { get; set; }

        public override string ToString() => TitleOfJob;
    }
}
