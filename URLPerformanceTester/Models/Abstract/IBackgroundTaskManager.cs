using System;
using System.Linq.Expressions;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IBackgroundTaskManager<T>
    {
        void AddTask(Expression<Action<T>> task);
    } 
}
