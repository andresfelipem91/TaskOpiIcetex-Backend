using Application.Interfaces;
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
            return await _repository.GetListTask();
        }
    }
}
