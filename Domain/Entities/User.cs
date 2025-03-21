﻿namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
