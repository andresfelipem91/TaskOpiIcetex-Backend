namespace Application.TaskopiIcetex
{
    public interface IEmailTask
    {
        Task Send(string transmitter,string receiver,string subject, string body, string html);
    }
}
