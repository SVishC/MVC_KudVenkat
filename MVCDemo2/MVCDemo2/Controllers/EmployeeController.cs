using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeList = new EmployeeBusinessLayer();
            List<Employee> employees = employeeList.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                empBusinessLayer.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = empBusinessLayer.Employees.Single(emp => emp.Id == id);

            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = empBusinessLayer.Employees.Single(e => e.Id == id);
            UpdateModel<IEmployee>(employee);
            if (ModelState.IsValid)
            {
                empBusinessLayer.SaveEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            empBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}