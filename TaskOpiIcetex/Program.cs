using Application.Interfaces;
using Application.SendEmail;
using Application.TaskopiIcetex;
using Application.TaskopiIcetex.Services;
using Infraestructure.TasksDbContext;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using TaskOpiIcetex;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TasksDB>(Options =>
{
    Options.UseOracle(builder.Configuration.GetConnectionString("conexion"),  b => b.MigrationsAssembly("TaskOpiIcetex"));
});
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ICreateTask,CreaterTask>();
builder.Services.AddScoped<IGetListTask,GetListTask>();
builder.Services.AddScoped<IGetTaskOne, GetTaskOne>();
builder.Services.AddScoped<IUpdateState, UpdateState>();
builder.Services.AddTransient<IEmailTask>(it => { 
  string apiKey= it.GetRequiredService<IConfiguration>().GetValue<string>("EmailKey");
    return new EmailServe(apiKey);
});
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddTransient<ISendEmail, SendEmail>();
builder.Services.AddTransient<INotificationTask, NotificationTask>();
//builder.Services.AddHostedService<Worker>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowWebapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
