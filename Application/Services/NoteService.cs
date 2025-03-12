using System.Windows.Forms;
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
        public async Task AddNoteAsync(Note note)
{
    _context.Notes.Add(note);
    await _context.SaveChangesAsync();
}

       
       public async Task<IEnumerable<NoteDTO>> GetAllNotesAsync(int? userId = null)
        {
            var query = _context.Notes
                .AsNoTracking();
            if (userId.HasValue)
            {
                query = query.Where(n => n.UserId == userId.Value);
            }
               return await _context.Notes
                .AsNoTracking() 
                .Select(n => new NoteDTO
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    ReminderDate = n.ReminderDate,
                    CreatedDate = n.CreatedDate,
                    UserId = n.UserId,
                    CategoryId = n.CategoryId 
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
                ReminderDate = note.ReminderDate,
                UserId = note.UserId,
                CategoryId = note.CategoryId,
                CreatedDate= note.CreatedDate,
            };
        }

        public async Task AddNoteAsync(NoteDTO noteDto)
        {
            var note = new Note
            {
                Title = noteDto.Title,
                Content = noteDto.Content,
                ReminderDate = noteDto.ReminderDate,
                CategoryId=noteDto.CategoryId,
                CreatedDate= noteDto.CreatedDate,
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
            note.ReminderDate = noteDto.ReminderDate;
            note.CreatedDate = noteDto.CreatedDate;
            note.CategoryId = noteDto.CategoryId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return;

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<NoteDTO>> SearchNotesAsync(string searchText, int? userId = null)
        {
            var query = _context.Notes.AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(n => n.UserId == userId.Value);
            }

            query = query.Where(n => n.Title.Contains(searchText) || n.Content.Contains(searchText));

            return await query.Select(n => new NoteDTO
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                CategoryId = n.CategoryId,
                ReminderDate = n.ReminderDate
            }).ToListAsync();
        }
        


    }
}
