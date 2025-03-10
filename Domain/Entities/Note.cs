
namespace Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ReminderDate { get; set; }
        public int? CategoryId { get; set; }  
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
