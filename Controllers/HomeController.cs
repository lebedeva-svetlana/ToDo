using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            NotesViewModel model = new(await _context.Notes.ToListAsync());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] NotesViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            model.ActiveNote.Id = 0;
            _context.Add(model.ActiveNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(NotesViewModel model)
        {
            if (_context.Notes == null)
            {
                return Problem("Entity set 'ApplicationContext.Note'  is null.");
            }
            var note = await _context.Notes.FindAsync(model.ActiveNote.Id);
            if (note != null)
            {
                _context.Notes.Remove(note);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }

        // Update

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NotesViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            if (model.ActiveNote.Title is null && model.ActiveNote.Text is null)
            {
                await Delete(model);
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Update(model.ActiveNote);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(model.ActiveNote.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //}
            //return View(note);
        }

        //// GET: Home/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Notes == null)
        //    {
        //        return NotFound();
        //    }

        //    var note = await _context.Notes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (note == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(note);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Notes == null)
        //    {
        //        return NotFound();
        //    }

        //    var note = await _context.Notes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (note == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(note);
        //}
    }
}