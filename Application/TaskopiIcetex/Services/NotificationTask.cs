using Application.Interfaces;
using Application.SendEmail;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskopiIcetex.Services
{
    public class NotificationTask : INotificationTask
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public NotificationTask(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task Notificate()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
               var _repository= scope.ServiceProvider.GetRequiredService<IRepository>();
               var _sendEmail= scope.ServiceProvider.GetRequiredService<ISendEmail>();
                var taskItem = await _repository.GetListTask();
                foreach (var task in taskItem)
                {
                    if (task.ExpirationDate < DateTime.Now)
                    {
                        await _sendEmail.SendEmailTask("andres.munozc@opitech.com.co", $"La tarea '{task.ExpirationDate}' ha vencido.");



                    }

                }
            }
           
        }
    }
}
