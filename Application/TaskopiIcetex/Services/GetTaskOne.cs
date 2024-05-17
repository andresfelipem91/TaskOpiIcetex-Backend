using Application.Interfaces;
using Domain.Models;


namespace Application.TaskopiIcetex.Services
{
    public class GetTaskOne:IGetTaskOne
    {
        private readonly IRepository _repository;
        public GetTaskOne(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskOpiModel> GetTaskOpi(string id)
        {
            return await _repository.GetTaskOpi(id);
        }
    }
}
