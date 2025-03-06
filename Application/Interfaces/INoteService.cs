using DigitalNotesManager.Application.DTOs;

namespace DigitalNotesManager.Application.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDTO>> GetAllNotesAsync();
        Task<NoteDTO?> GetNoteByIdAsync(int id);
        Task AddNoteAsync(NoteDTO noteDto);
        Task UpdateNoteAsync(NoteDTO noteDto);
        Task DeleteNoteAsync(int id);
    }
}
