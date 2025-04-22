using System.ComponentModel.DataAnnotations;

namespace ToDo_List_MVC.Models.Entity
{
    public class NoteDetail
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? Note { get; set; }

        public DateOnly? ScheduleDate { get; set; }

        public TimeOnly? ScheduleTime { get; set; }

        public bool IsSunday { get; set; }

        public bool IsMonday { get; set; }

        public bool IsTuesday { get; set; }
        
        public bool IsWednesday { get; set; }
        
        public bool IsThursday { get; set; }
        
        public bool IsFriday { get; set; }
        
        public bool IsSaturday { get; set; }

    }
}
