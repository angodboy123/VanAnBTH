using BTH19_03.Data;
using BTH19_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTH19_03.Controllers

{
    public class StudentController : Controller{
        private readonly ApplicationDbContext _context;
        public StudentController (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Students.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Student std)
        
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(std);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if( id == null)
            {
                return View("NotFound");
            }

            var student = await _context.Students.FindAsync(id);
            if(student == null)
            {
                return View("NotFound");
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
// Edit
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName")] Student std)
        {
            if(id != std.StudentID)
            {
                return View("NotFound");
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(std);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!StudentExists(std.StudentID))
                    {
                        return View("NotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(std);
        }
        //Delelte
            public async Task<IActionResult> Delete(string id)
        {
            if(id == null)
            {
                return View("NotFound");
            }

            var std = await _context.Students.FirstOrDefaultAsync(m => m.StudentID ==id);
            if(std == null)
            {
                return View("NotFound");
            }
            return View(std);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var std = await _context.Students.FindAsync(id);
            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.StudentID ==id);
        }


    }
}