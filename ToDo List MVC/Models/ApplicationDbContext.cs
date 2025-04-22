using Microsoft.EntityFrameworkCore;
using ToDo_List_MVC.Models.Entity;

namespace ToDo_List_MVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<NoteDetail> NoteDetails { get; set; }
    }
}
