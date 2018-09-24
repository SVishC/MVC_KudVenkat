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
        public ActionResult Edit_Post([Bind(Include = "Id,Gender,City,DateOfBirth")]Employee employee)
        {
            
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            employee.Name = empBusinessLayer.Employees.Single(emp => emp.Id == employee.Id).Name;
            //Employee employee = empBusinessLayer.Employees.Single(e => e.Id == id);
           // UpdateModel(employee, new string[] { "Id", "Gender", "City", "DateOfBirth" });
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
    }
}