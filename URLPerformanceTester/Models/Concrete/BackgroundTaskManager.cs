using System;
using System.Linq.Expressions;
using Hangfire;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    class BackgroundTaskManager<T> : IBackgroundTaskManager<T>
    {
        public void AddTask(Expression<Action<T>> task)
        {
            BackgroundJob.Enqueue<T>(task);
        }
    }
}