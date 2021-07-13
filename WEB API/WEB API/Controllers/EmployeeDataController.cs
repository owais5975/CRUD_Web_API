using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API.Models;

namespace WEB_API.Controllers
{
    public class EmployeeDataController : ApiController
    {
        StudentDBEntities db = new StudentDBEntities();

        //Create
        [HttpPost]
        public string AddEmployee(string name, string department)
        {
            Student std = new Student();
            std.Name = name;
            std.Department = department;

            db.Students.Add(std);
            int a = db.SaveChanges();

            var result = a > 0 ? "Added Successfully" : "Failed";

            return result;
        }

        //Read All
        [HttpPost]
        public List<Student> GetEmployee(int id)
        {
            var data = db.Students.Where(x => x.Id.Equals(id)).ToList();
            return data;
        }

        //Read
        [HttpGet]
        public List<Student> GetAllEmployees()
        {
            var data = db.Students.ToList();
            return data;
        }

        //Update
        [HttpPost]
        public string UpdateEmployee(int id, string name, string department)
        {
            Student std = db.Students.Where(x => x.Id.Equals(id)).Select(x => x).FirstOrDefault();
            std.Name = name;
            std.Department = department;

            db.Entry(std).State = EntityState.Modified;
            int a = db.SaveChanges();

            var result = a > 0 ? "Updated Successfully" : "Failed";

            return result;
        }

        //Delete
        [HttpPost]
        public string DeleteEmployee(int id)
        {
            var data = db.Students.Where(x => x.Id.Equals(id)).FirstOrDefault();
            db.Students.Remove(data);
            int a = db.SaveChanges();

            var result = a > 0 ? "Deleted Successfully" : "Failed";

            return result;
        }

    }
}
