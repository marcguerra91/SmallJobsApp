﻿using SmallJob.Data;
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
                    Email = model.Email
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

                        }
                        );
                return query.ToArray();

            }
        } 
    }
}