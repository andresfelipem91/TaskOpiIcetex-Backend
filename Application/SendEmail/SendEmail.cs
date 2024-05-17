using Application.TaskopiIcetex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendEmail
{
   
    public class SendEmail(IEmailTask emailTask) : ISendEmail
    {
        private readonly IEmailTask _emailTask= emailTask;

    

        public async Task SendEmailTask(string emailReceiver, string bodyMessege)
        {
            await _emailTask.Send("andresfelipem.91@hotmail.com", emailReceiver, "Correo Prueba", bodyMessege, null);
        }
      
    }
}

