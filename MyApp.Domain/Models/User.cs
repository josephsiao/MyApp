using MyApp.Shared.Common;

namespace MyApp.Domain.Models
{
    public class User
    {
        [Column(Name = "user_id")]
        public int Id { get; set; }

        [Column(Name = "user_name")]
        public string Username { get; set; }
        // 其他屬性...
    }
}
