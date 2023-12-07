using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Human_Resource_Management_System.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly RepositoryContext _context;

        public DepartmentController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model=_context.Departments;
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Departments.Add(department);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Create");
            }
            catch (Exception)
            {

                throw;
            }

        }


        public IActionResult Update(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Department department)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
