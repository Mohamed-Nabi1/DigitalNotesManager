using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalNotesManager.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NoteDTO>> GetAllNotesAsync()
        {
            return await _context.Notes
                .Select(n => new NoteDTO
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    CreatedAt = n.CreatedDate,
                    UserId = n.UserId
                })
                .ToListAsync();
        }

        public async Task<NoteDTO?> GetNoteByIdAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return null;

            return new NoteDTO
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedDate,
                UserId = note.UserId
            };
        }

        public async Task AddNoteAsync(NoteDTO noteDto)
        {
            var note = new Note
            {
                Title = noteDto.Title,
                Content = noteDto.Content,
                CreatedDate = DateTime.UtcNow,
                UserId = noteDto.UserId
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNoteAsync(NoteDTO noteDto)
        {
            var note = await _context.Notes.FindAsync(noteDto.Id);
            if (note == null) return;

            note.Title = noteDto.Title;
            note.Content = noteDto.Content;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return;

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
