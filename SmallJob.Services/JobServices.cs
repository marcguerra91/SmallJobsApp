using SmallJob.Data;
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
                                Pay = e.Pay,
                                CreatedUtc = e.CreatedUtc
                            }
                         );
             return query.ToArray();
            }
        }

        public JobDetail GetJobById(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jobs
                    .Single(e => e.JobId == jobId && e.OwnerId == _userId);
                return
                    new JobDetail
                    {
                        JobId = entity.JobId,
                        TitleOfJob = entity.TitleOfJob,
                        Description = entity.Description,
                        Pay = entity.Pay,
                        EquipmentAvailable = entity.EquipmentAvailable,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateJob(JobEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jobs
                    .Single(e => e.JobId == model.JobId && e.OwnerId == _userId);

                entity.TitleOfJob = model.TitleOfJob;
                entity.Description = model.Description;
                entity.Pay = model.Pay;
                entity.EquipmentAvailable = model.EquipmentAvailable;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJob(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jobs
                    .Single(e => e.JobId == jobId && e.OwnerId == _userId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
