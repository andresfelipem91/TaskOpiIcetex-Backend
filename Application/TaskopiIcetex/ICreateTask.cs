using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskopiIcetex
{
    public interface ICreateTask
    {
        Task<TaskOpiModel> AddTask(string Title, State IsState, Priority priority,DateTime ExpirationDate,string Detail);
    }
}
