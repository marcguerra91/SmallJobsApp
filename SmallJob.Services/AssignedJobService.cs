using SmallJob.Data;
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
                            TitleOfJob = e.TitleOfJob,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
