using Domain.Enums;


namespace Domain.Models
{
    public class TaskOpiModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string? Title { get; set; }
        public State IsState { get; set; }
        public Priority Priority { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? Detail {  get; set; }
        public UserModel? Users { get; set; }
    }
}
