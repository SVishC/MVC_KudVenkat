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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            Employee employee = new Employee();
            employee.Name = formCollection["Name"];
            employee.Gender = formCollection["Gender"];
            employee.City = formCollection["City"];
            employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);

            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            empBusinessLayer.AddEmployee(employee);

            return RedirectToAction("Index");
        }
    }
}