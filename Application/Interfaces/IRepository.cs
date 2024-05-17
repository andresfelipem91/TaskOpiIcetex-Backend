using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository
    {
        Task<List<TaskOpiModel>> GetListTask();
        Task<TaskOpiModel> GetTaskOpi(string id);
        Task<TaskOpiModel> AddTask(TaskOpiModel task);
        Task UpdateTasksOpi(TaskOpiModel task);



    }
}
