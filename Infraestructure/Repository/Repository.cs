
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Infraestructure.TasksDbContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Repository: IRepository
    {
        private readonly TasksDB _context;
        public Repository(TasksDB context) 
        { 
         _context = context;
        }

        public async Task<TaskOpiModel> AddTask(TaskOpiModel task)
        {
            _context.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<List<TaskOpiModel>> GetListTask()
        {
          return  await _context.TaskOpiTasks.ToListAsync();
        }


        public async Task<TaskOpiModel> GetTasKByIdAsync(string taskId)
        {
            return await _context.TaskOpiTasks.FindAsync(taskId);
        }

        public async Task<TaskOpiModel> GetTaskOpi(string id)
        {
            var Task = await _context.TaskOpiTasks.FindAsync(id);
            return Task;
        }


        public async Task UpdateTasksOpi(TaskOpiModel taskOpi)
        {
            _context.Update(taskOpi);
            await _context.SaveChangesAsync();
        }
    }
}
