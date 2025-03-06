using Domain.Entities;


namespace Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<Note?> GetByIdAsync(int id);
        Task<IEnumerable<Note>> GetAllAsync();
        Task<IEnumerable<Note>> GetNotesByUserIdAsync(int userId);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(int id);
    }
}
