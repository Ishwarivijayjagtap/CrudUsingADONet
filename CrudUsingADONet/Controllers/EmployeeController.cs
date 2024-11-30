using CrudUsingADONet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace CrudUsingADONet.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IConfiguration configuration;
        private readonly EmployeeCrud db;
        public ActionResult Create(Employee emp)
        {
            try
            {
                int response = db.AddEmployee(emp);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }





        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new EmployeeCrud(this.configuration);
        }
       
        // All employees  Employee/Index 
        public ActionResult Index()
        {
            var response = db.GetEmployees();
            return View(response);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = db.GetEmployeeById(id);
            return View(res);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int response = db.UpdateEmployee(emp);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var res = db.GetEmployeeById(id);
            return View(res);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = db.GetEmployeeById(id);
            return View(res);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")] // This informs CLR that DeleteConfirm is the HttpPost method against Delete
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int response = db.DeleteEmployee(id);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
