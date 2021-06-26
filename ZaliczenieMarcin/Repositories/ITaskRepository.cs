using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZaliczenieMarcin.Models;

namespace ZaliczenieMarcin.Repositories
{
    public interface ITaskRepository
    {
        TaskModel Get(int id);
        IQueryable<TaskModel> GetAllActive();
        void Add(TaskModel task);
        void Update(int taskId, TaskModel task);
        void Delete(int taskId);
    }
}
