using SendGrid.Helpers.Mail;
using SendGrid;
using Application.TaskopiIcetex;

namespace Infrastructure.Services
{
    public class EmailServe(string apiKey) : IEmailTask
    {
        private readonly string _apiKey = apiKey;

   

        public async Task Send(string transmitter, string receiver, string subject, string body, string html)
        {
            SendGridClient client = new(_apiKey);
            EmailAddress from = new(transmitter);
            EmailAddress to = new (receiver);
            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject,body, html);
            Response response = await client.SendEmailAsync(msg);
          
        }

    }
}
