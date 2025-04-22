using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo_List_MVC.Models;
using ToDo_List_MVC.Models.Entity;
using ToDo_List_MVC.Repository;

namespace ToDo_List_MVC.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoListRL _toDoListRL;

        public ToDoController(IToDoListRL toDoListRL) => _toDoListRL = toDoListRL;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<NoteDetail>? noteDetails = await _toDoListRL.GetNotes();
            return View(noteDetails);
        }

        [HttpGet]
        public IActionResult InsertNote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertNote(AddNoteDetail request)
        {
            await _toDoListRL.InsertNote(request);
            return RedirectToAction("Index", "ToDo");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNote(Guid Id)
        {
            NoteDetail? noteDetail = await _toDoListRL.GetNoteById(Id);
            return View(noteDetail);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNote(NoteDetail request)
        {
            await _toDoListRL.UpdateNote(request);
            return RedirectToAction("Index", "ToDo");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            await _toDoListRL.DeleteNote(id);
            return RedirectToAction("Index", "ToDo");
        }
    }
}
