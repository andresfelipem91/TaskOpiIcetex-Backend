using Application.Interfaces;
using Domain.Enums;
using Domain.Models;


namespace Application.TaskopiIcetex.Services
{
    public class UpdateState:IUpdateState
    {
        private readonly IRepository _repository;

        public UpdateState(IRepository repository)
        {
            _repository = repository;
        }

    

        public async Task UpdateTasksOpi(string id, State IsState)
        {
            TaskOpiModel taskItem = await _repository.GetTaskOpi(id);
            if (taskItem != null) {
                taskItem.IsState = IsState;
                await _repository.UpdateTasksOpi(taskItem);
            }
        }
    }
}
