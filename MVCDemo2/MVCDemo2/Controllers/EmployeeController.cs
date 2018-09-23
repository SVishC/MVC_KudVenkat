﻿using BusinessLayer;
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
        public ActionResult Create(string Name,string Gender,string City,DateTime DateOfBirth)
        {
            Employee employee = new Employee();
            employee.Name = Name;
            employee.Gender = Gender;
            employee.City = City;
            employee.DateOfBirth = DateOfBirth;

            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            empBusinessLayer.AddEmployee(employee);

            return RedirectToAction("Index");
        }
    }
}