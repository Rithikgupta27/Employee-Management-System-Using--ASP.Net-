using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            List<Employee> list = Employee.GetAll();
            return View(list);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            Employee emp = Employee.GetDetails(id);
            return View(emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,Employee obj)
        {
            try
            {
                Employee.Insert(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee emp = Employee.GetDetails(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Employee obj, IFormCollection collection)
        {
            try
            {
                Employee.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = Employee.GetDetails(id);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
