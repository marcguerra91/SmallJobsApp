﻿using SmallJob.Data;
using SmallJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Services
{
    public class AssignedJobService
    {
        private readonly Guid _userId;

        public AssignedJobService(Guid userId)
        {

            _userId = userId;
        }

        public bool CreateAssignedJobs(AssignedJobsCreate model)
        {
            var entity =
                new AssignedJobs()
                {
                    OwnerId = _userId,
                    JobId = model.JobId,
                    TitleOfJob = model.TitleOfJob,
                    EquipmentAvailable = model.EquipmentAvailable,
                    WorkerId = model.WorkerId,
                    CreatedUtc = DateTimeOffset.Now

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AssignedJobListItem> GetAssignedJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Assignments
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new AssignedJobListItem
                        {
                            AssignmentId = e.AssignmentId,
                            JobId = e.JobId,
                            TitleOfJob = e.TitleOfJob,
                            WorkerId = e.WorkerId,
                            JobComplete = e.JobComplete,
                            Worker = e.Worker,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }

        public AssignedJobDetail GetAssignedJobById(int assignmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assignments
                    .Single(e => e.AssignmentId == assignmentId && e.OwnerId == _userId);
                return
                    new AssignedJobDetail
                    {
                        AssignmentId = entity.AssignmentId,
                        JobId = entity.JobId,
                        TitleOfJob = entity.Jobs.TitleOfJob,
                        FullName = entity.Worker.FullName,
                        EquipmentAvailable = entity.EquipmentAvailable,
                        WorkerId = entity.WorkerId,
                        JobComplete = entity.JobComplete,
                        CreatedUtc = entity.CreatedUtc
                        
                    };
            }
        }

        public bool UpdateAssignedJob(AssignedJobEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assignments
                    .Single(e => e.AssignmentId == model.AssignmentId && e.OwnerId == _userId);

                entity.JobId = model.JobId;
                entity.TitleOfJob = model.TitleOfJob;
                entity.WorkerId = model.WorkerId;
                entity.JobComplete = model.JobComplete;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAssignedJob(int assignmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                    .Assignments
                    .Single(e => e.AssignmentId == assignmentId && e.OwnerId == _userId);

                ctx.Assignments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
