using CrudUsingADONet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingADONet.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        private readonly IConfiguration configuration;
        private readonly StudentCrud db;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new StudentCrud(this.configuration);
        }

        public ActionResult Index()
        {
            var response = db.GetStudents();
              return View(response);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var res = db.GetStudentById(id);
            return View(res);
            
        }

        // GET: StudentController/Create
        public ActionResult Create(Student std)
        {
            try
            {
                int response = db.AddStudent(std);
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
        

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {

            var res = db.GetStudentById(id);
            return View(res);
            
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student std)
        {
            try
            {
                int response = db.UpdateStudent(std);
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
        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = db.GetStudentById(id);
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
                int response = db.DeleteStudent(id);
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
