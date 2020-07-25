using System.Collections.Generic;
using System.Linq;
using DLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class StudentController : MainApiController
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
        public IActionResult Insert(Student student)
        {
            return Ok(StudentStatic.InsertStudent(student));
        }

        [HttpPut("{email}")]
        public IActionResult Update(string email, Student student)
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
        private static List<DLL.Model.Student> AllStudent { get; set; } = new List<DLL.Model.Student>();

        public static Student InsertStudent(Student Student)
        {
            AllStudent.Add(Student);
            return Student;
        }

        public static List<Student> GetAllStudent()
        {
            return AllStudent;
        }

        public static Student GetAStudent(string email)
        {
            return AllStudent.FirstOrDefault(x => x.Email == email);
        }

        public static DLL.Model.Student UpdateStudent(string email, DLL.Model.Student Student)
        {
            DLL.Model.Student result = new Student();
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

        public static Student DeleteStudent(string email)
        {
            var Student = AllStudent.FirstOrDefault(x => x.Email == email);
            AllStudent = AllStudent.Where(x => x.Email != Student.Email).ToList();

            return Student;

        }
    }

}
