using Domain.Enums;

namespace Application.TaskopiIcetex
{
    public interface IUpdateState
    {
        Task UpdateTasksOpi(string id,State IsState);
    }
}
