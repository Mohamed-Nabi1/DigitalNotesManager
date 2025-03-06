using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Note?> GetByIdAsync(int id) => await _context.Notes.FindAsync(id);

        public async Task<IEnumerable<Note>> GetAllAsync() => await _context.Notes.ToListAsync();

        public async Task<IEnumerable<Note>> GetNotesByUserIdAsync(int userId)
            => await _context.Notes.Where(n => n.UserId == userId).ToListAsync();

        public async Task AddAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }
    }
}
