using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskopiIcetex.Services
{
    public  class GetListTask:IGetListTask
    {
        private readonly IRepository _repository;
        public GetListTask(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskOpiModel>> GetListTasks()
        {
           List<TaskOpiModel> filterTask= await _repository.GetListTask();
            return (filterTask.OrderByDescending(filter=> filter.Priority == Priority.high).ThenBy(filter=> filter.Priority == Priority.half)).ToList();
            
        }
    }
}
