using Microsoft.EntityFrameworkCore;
using ToDo_List_MVC.Models;
using ToDo_List_MVC.Models.Entity;

namespace ToDo_List_MVC.Repository
{
    public class ToDoListRL : IToDoListRL
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoListRL(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteNote(Guid Id)
        {
            NoteDetail? noteDetail = await _dbContext.NoteDetails.FindAsync(Id);
            if (noteDetail is null)
                return;
            _dbContext.NoteDetails.Remove(noteDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<NoteDetail?> GetNoteById(Guid Id)
        {
            NoteDetail? noteDetail = await _dbContext.NoteDetails.FindAsync(Id);
            if (noteDetail is null)
                return null;
            return noteDetail;
        }

        public async Task<List<NoteDetail>?> GetNotes()
        {
            return await _dbContext.NoteDetails.ToListAsync();
        }

        public async Task InsertNote(AddNoteDetail request)
        {
            NoteDetail noteDetail = new NoteDetail()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Note = request.Note,
                ScheduleDate = request.ScheduleDate,
                ScheduleTime = request.ScheduleTime,
                IsSunday = request.IsSunday,
                IsMonday = request.IsMonday,
                IsTuesday = request.IsTuesday,
                IsWednesday = request.IsWednesday,
                IsThursday = request.IsThursday,
                IsFriday = request.IsFriday,
                IsSaturday = request.IsSaturday
            };

            await _dbContext.NoteDetails.AddAsync(noteDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNote(NoteDetail request)
        {
            NoteDetail? noteDetail = await _dbContext.NoteDetails.FindAsync(request.Id);
            if (noteDetail is null)
                return;
            noteDetail.Note = request.Note;
            noteDetail.ScheduleDate = request.ScheduleDate;
            noteDetail.ScheduleTime = request.ScheduleTime;
            noteDetail.IsSunday = request.IsSunday;
            noteDetail.IsMonday = request.IsMonday;
            noteDetail.IsTuesday = request.IsTuesday;
            noteDetail.IsWednesday = request.IsWednesday;
            noteDetail.IsThursday = request.IsThursday;
            noteDetail.IsFriday = request.IsFriday;
            noteDetail.IsSaturday = request.IsSaturday;
            await _dbContext.SaveChangesAsync();
        }
    }
}
