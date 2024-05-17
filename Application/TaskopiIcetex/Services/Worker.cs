using Application.Interfaces;
using Application.SendEmail;
using Application.TaskopiIcetex;
using Application.TaskopiIcetex.Services;
using Domain.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TaskOpiIcetex
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly INotificationTask _notificationTask;
        public Worker(ILogger<Worker> logger, INotificationTask notificationTask)
        {
            _logger = logger;
             _notificationTask = notificationTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _notificationTask.Notificate();
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
