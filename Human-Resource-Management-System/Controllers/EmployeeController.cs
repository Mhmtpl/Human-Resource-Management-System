using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Human_Resource_Management_System.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly RepositoryContext _context;

        public EmployeeController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Create");
        }

        public IActionResult Update(int id)
        {
            var model = _context.Employees.FirstOrDefault(x => x.Equals(id));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] Employee employee)
        {

            var model = _context.Employees.FirstOrDefault(x => x.EmployeeId.Equals(employee.Id));

            if (model is not null)
            {
                model.FirstName = employee.FirstName;
                model.LastName = employee.LastName;
                model.DateOfBirth = employee.DateOfBirth;
                _context.SaveChanges();
            }
            else
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = _context.Employees.Find(id);
            if (model is not null)
            {
                _context.Employees.Remove(model);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
