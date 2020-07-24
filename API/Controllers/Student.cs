using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class Student : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentStatic.GetAllStudent());
        }
        [HttpGet("{email}")]
        public IActionResult GetA(string email)
        {
            return Ok(StudentStatic.GetAStudent(email));
        }

        [HttpPost]
        public IActionResult Insert(Models.Student student)
        {
            return Ok(StudentStatic.InsertStudent(student));
        }

        [HttpPut("{email}")]
        public IActionResult Update(string email, Models.Student student)
        {
            return Ok(StudentStatic.UpdateStudent(email, student));
        }
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            return Ok(StudentStatic.DeleteStudent(email));
        }
    }

    public static class StudentStatic
    {
        private static List<API.Models.Student> AllStudent { get; set; } = new List<Models.Student>();

        public static API.Models.Student InsertStudent(API.Models.Student Student)
        {
            AllStudent.Add(Student);
            return Student;
        }

        public static List<Models.Student> GetAllStudent()
        {
            return AllStudent;
        }

        public static Models.Student GetAStudent(string email)
        {
            return AllStudent.FirstOrDefault(x => x.Email == email);
        }

        public static Models.Student UpdateStudent(string email, API.Models.Student Student)
        {
            Models.Student result = new API.Models.Student();
            foreach (var aStudent in AllStudent)
            {
                if (email == aStudent.Email)
                {
                    aStudent.Name = Student.Name;
                    result = aStudent;
                }
            }
            return result;
        }

        public static Models.Student DeleteStudent(string email)
        {
            var Student = AllStudent.FirstOrDefault(x => x.Email == email);
            AllStudent = AllStudent.Where(x => x.Email != Student.Email).ToList();

            return Student;

        }
    }

}
