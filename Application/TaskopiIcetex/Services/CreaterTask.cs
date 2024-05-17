using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using System.Threading.Tasks;

namespace Application.TaskopiIcetex.Services
{
    public class CreaterTask : ICreateTask
    {
        private readonly IRepository _repository;
        public CreaterTask(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<TaskOpiModel> AddTask(string Title, State IsState, Priority Priority, DateTime ExpirationDate, string Detail)
        {
            TaskOpiModel taskopimodel = new TaskOpiModel()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = "1",
                Title = Title,
                IsState = IsState,
                Priority = Priority,
                ExpirationDate = ExpirationDate,
                Detail = Detail
            };

       
            await _repository.AddTask(taskopimodel);
            return taskopimodel;
        }
       
    }
}
