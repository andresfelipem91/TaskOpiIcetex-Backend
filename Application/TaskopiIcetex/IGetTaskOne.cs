using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskopiIcetex
{
    public interface IGetTaskOne
    {
        Task<TaskOpiModel> GetTaskOpi(string id);
    }
}
