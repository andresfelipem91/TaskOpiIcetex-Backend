using Application.SendEmail;
using Application.TaskopiIcetex;
using Application.TaskopiIcetex.Services;
using Domain.Enums;
using Domain.Models;
using Infraestructure.TasksDbContext;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;


namespace TaskOpiIcetex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksOpiIcetexController : ControllerBase
    {
        private readonly ICreateTask _createTask;
        private readonly IGetListTask _getListTask;
        private readonly IGetTaskOne _getTaskOne;
        private readonly IUpdateState _updateState;
        private readonly ISendEmail _sendEmail;
        
       


        public TasksOpiIcetexController(ICreateTask createTask, IGetListTask getListTask, IGetTaskOne getTaskOne, IUpdateState updateState,TasksDB tasksDB, ISendEmail sendEmail)
        {
            _createTask = createTask;
            _getListTask = getListTask;
            _getTaskOne = getTaskOne;
            _updateState = updateState;
            _sendEmail = sendEmail;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListTask = await _getListTask.GetListTasks();
                return Ok(ListTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var Task = await _getTaskOne.GetTaskOpi(id);
                return Ok(Task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<TaskOpiModel>? Post(CreateTaskopi createTaskopi)
        {

            return await _createTask.AddTask( createTaskopi.Title, createTaskopi.IsState, createTaskopi.Priority,
                createTaskopi.ExpirationDate, createTaskopi.Detail);



        }
        [HttpPut]
        public async Task Put(UdateTaskopi createTaskopi)
        {
                
                await _updateState.UpdateTasksOpi(createTaskopi.Id,createTaskopi.IsState);
        }

        [HttpPost]
        [Route("/sendEmail")]
        public async Task SendEmail(SendEmailMode sendEmail)
        {
             await _sendEmail.SendEmailTask(sendEmail.EmailReceiver,sendEmail.BodyMenssage);
        }

     

    }
    public class CreateTaskopi
    {
        public string Title { get; set; }
        public State IsState { get; set; }
        public Priority Priority { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Detail { get; set; }
    }
    public class UdateTaskopi
    {
        public string Id { get; set; }
        public State IsState { get; set; }
    }
}
