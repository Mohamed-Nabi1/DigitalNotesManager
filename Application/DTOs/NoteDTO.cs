namespace DigitalNotesManager.Application.DTOs
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } 
        public DateTime? ReminderDate { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? CategoryId { get; set; }

        
    }
}
