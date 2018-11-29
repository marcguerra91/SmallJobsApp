﻿using SmallJob.Data;
using SmallJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Services
{
    public class JobServices
    {
        private readonly Guid _userId;

        public JobServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJob(JobCreate model)
        {
            var entity =
                new JobsAvailable()
                {
                    OwnerId = _userId,
                    TitleOfJob = model.TitleOfJob,
                    Description = model.Description,
                    Pay = model.Pay,
                    EquipmentAvailable = model.EquipmentAvailable,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }

                }
        public IEnumerable<JobsListItem> GetJobs()
            {
             using (var ctx = new ApplicationDbContext())
             {
             var query =
                    ctx
                        .Jobs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new JobsListItem
                            {
                                JobId = e.JobId,
                                TitleOfJob = e.TitleOfJob,
                                CreatedUtc = e.CreatedUtc
                            }
                         );
             return query.ToArray();
            }
        }
    }
}