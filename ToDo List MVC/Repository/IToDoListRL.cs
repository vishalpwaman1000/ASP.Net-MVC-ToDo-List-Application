using ToDo_List_MVC.Models;
using ToDo_List_MVC.Models.Entity;

namespace ToDo_List_MVC.Repository
{
    public interface IToDoListRL
    {
        Task InsertNote(AddNoteDetail request);
        Task<List<NoteDetail>?> GetNotes();
        Task<NoteDetail?> GetNoteById(Guid Id);
        Task UpdateNote(NoteDetail request);
        Task DeleteNote(Guid Id);
    }
}
