using SmallJob.Data;
using SmallJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Services
{
    public class WorkerService
    {
        private readonly Guid _userId;

        public WorkerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorker(WorkerCreate model)
        {
            var entity =
                new Worker()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Workers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkerListItem> GetWorkers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Workers
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => 
                        new WorkerListItem
                        {
                            WorkerId = e.WorkerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Email = e.Email,
                            PhoneNumber = e.PhoneNumber,
                            CreatedUtc = e.CreatedUtc
                        }
                     );
                return query.ToArray();

            }
        }

        public WorkerDetail GetWorkerById(int workerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
            var entity =
                ctx
                .Workers
                .Single(e => e.WorkerId == workerId && e.OwnerId == _userId);
                return
                    new WorkerDetail
                    {
                        WorkerId = entity.WorkerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        PhoneNumber = entity.PhoneNumber,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        public bool UpdateWorker(WorkerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workers
                    .Single(e => e.WorkerId == model.WorkerId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteWorker(int workerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workers
                    .Single(e => e.WorkerId == workerId && e.OwnerId == _userId);

                ctx.Workers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
