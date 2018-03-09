using APIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace MVC_Client.Controllers
{
    [RoutePrefix("Emp")]
    public class EmployeeController : Controller
    {
        static RestSharpClient<EmployeeViewModel> empRestSharpClient = null;
        static RestSharpClient<DepartmentViewModel> depRestSharpClient = null;

        public EmployeeController()
        {
            if (empRestSharpClient == null)
            { 
                empRestSharpClient = new RestSharpClient<EmployeeViewModel>("http://localhost:57705/", "api/Employee/");
                depRestSharpClient = new RestSharpClient<DepartmentViewModel>("http://localhost:57705/", "api/Department/");
            }
        }

        #region read

        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var employees = empRestSharpClient.Get();
                return View(employees);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var employee = empRestSharpClient.Get(id);
                return View(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion read

        #region create
        // GET: Employee/Create
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                var vm = new EmployeeViewModel
                {
                    Departments = depRestSharpClient.Get()
                };
                return View(vm);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empRestSharpClient.Insert(employeeViewModel);
                    return RedirectToAction("Index");                   
                }
                employeeViewModel.Departments = depRestSharpClient.Get();
                return View(employeeViewModel);
            }
            catch
            {
                return View();
            }
        }

        #endregion


        // GET: Employee/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var employee = empRestSharpClient.Get(id);
                employee.Departments = depRestSharpClient.Get();
                return View(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    empRestSharpClient.Update(employeeViewModel);
                    return RedirectToAction("Index");
                }
                employeeViewModel.Departments = depRestSharpClient.Get();
                return View(employeeViewModel);

            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
