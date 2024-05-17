
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Infraestructure.TasksDbContext;

public class TasksDB : DbContext
{
    public TasksDB(DbContextOptions<TasksDB> options) : base(options) { }
    public DbSet<TaskOpiModel> TaskOpiTasks { get; set; }
    public DbSet<UserModel> UserModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskOpiModel>(entity =>
        {
            entity.HasKey(task => task.Id);
            entity.Property(taask => taask.Title).IsRequired();
            entity.Property(task => task.IsState).IsRequired();
            entity.Property(task => task.Detail).IsRequired();
            entity.Property(task => task.Priority).IsRequired();
            entity.Property(task => task.ExpirationDate).IsRequired();
            


        }

        );
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(user => user.UserId);
            entity.Property(user => user.Email).IsRequired();
            entity.Property(user => user.Password).IsRequired();
            entity.Property(user => user.notification).IsRequired();
        });

        modelBuilder.Entity<TaskOpiModel>().HasOne(task=>task.Users);
           
    }

}
