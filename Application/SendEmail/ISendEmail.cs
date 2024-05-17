namespace Application.SendEmail
{
    public interface ISendEmail
    {
       Task SendEmailTask(string emailReceiver, string bodyMessege);
    }
}
