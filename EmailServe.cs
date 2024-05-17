using SendGrid.Helpers.Mail;
using SendGrid;

namespace Application.TaskopiIcetex.Services
{
    public class EmailServe : IEmailTask
    {
        private readonly string _email;

        public EmailServe(string email)
        {
            _email = email;
        }

        public async Task SendEmailAsync(string email, string subjectEmail, string body)
        {
            var apiKey = Environment.GetEnvironmentVariable("SG. F68EF4sCRPSJ8oyHswcHjQ.wEJ8ebS3o7SutU-VArN23hndyZyC3JizKHNHwyGA2DE");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("andresfelipem.91@hotmail.com", "Prueba de correo");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(email);
            var plainTextContent = body;
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers);
        }

    }
}
