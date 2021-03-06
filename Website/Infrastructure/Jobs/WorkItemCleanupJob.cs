﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using WebBackgrounder;

namespace NuGetGallery.Jobs
{
    public class WorkItemCleanupJob : Job
    {
        private Func<DbContext> _contextThunk;

        public WorkItemCleanupJob(TimeSpan interval, Func<DbContext> contextThunk)
            : base("WorkItem Cleanup", interval)
        {
            if (contextThunk == null)
            {
                throw new ArgumentNullException("context");
            }
            _contextThunk = contextThunk;
        }

        public override Task Execute()
        {
            return new Task(UpdateStats);
        }

        private void UpdateStats()
        {
            const string sql = @"DELETE WorkItems WHERE Completed <  DATEADD(month, -1, getutcdate())";
            using (var context = _contextThunk())
            {
                context.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}