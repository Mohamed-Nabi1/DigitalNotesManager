using DigitalNotesManager.Application.DTOs;
using Domain.Entities;

namespace DigitalNotesManager.Application.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDTO>> GetAllNotesAsync(int userId);
        Task<NoteDTO?> GetNoteByIdAsync(int id);
        Task AddNoteAsync(NoteDTO noteDto);
        Task UpdateNoteAsync(NoteDTO noteDto);
        Task DeleteNoteAsync(int id);
        Task AddNoteAsync(Note newNote);
        Task<IEnumerable<NoteDTO>> SearchNotesAsync(string searchText, int? userId );
    }
}
