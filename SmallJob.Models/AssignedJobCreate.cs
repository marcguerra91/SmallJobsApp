﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class AssignedJobsCreate
    {

        public int AssignmentId { get; set; }

        public int JobId { get; set; }

        public string TitleOfJob { get; set; }

        public int WorkerId { get; set; }

        public override string ToString() => TitleOfJob;
    }
}