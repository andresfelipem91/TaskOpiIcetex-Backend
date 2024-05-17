
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public  class UserModel
    {
        [Key]
        public string UserId { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public NotificationPreference? notification { get; set; }
     
    }
}
