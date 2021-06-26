using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZaliczenieMarcin.Models;

namespace ZaliczenieMarcin.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerContext _context;
        public TaskRepository(TaskManagerContext context)
        {
            _context = context;
        }
        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Delete(int taskId)
        {
            var result = _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);
            if (result != null)
            {
                _context.Tasks.Remove(result);
                _context.SaveChanges();
            }

        }

        public TaskModel Get(int id)
            => _context.Tasks.SingleOrDefault(x => x.TaskId == id);


        public IQueryable<TaskModel> GetAllActive()
       => _context.Tasks.Where(x => !x.Done);
        public void Update(int taskId, TaskModel task)
        {
            var result = _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);
            if (result != null)
            {
                result.Name = task.Name;
                result.Description = task.Description;
                result.Done = task.Done;

                _context.SaveChanges();
                    
            }
        }
    }
}
