using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DepartmentStatic.GetAllDepartment());
        }
        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            return Ok(DepartmentStatic.GetADepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(DLL.Model.Department department)
        {
            return Ok(DepartmentStatic.InsertDepartment(department));
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, DLL.Model.Department department)
        {
            return Ok(DepartmentStatic.UpdateDepartment(code,department));
        }
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(DepartmentStatic.DeleteDepartment(code));
        }

    }


    public static class DepartmentStatic
    {
        private static List<Department> AllDepartment { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            AllDepartment.Add(department);
            return department;
        }

        public static List<Department> GetAllDepartment()
        {
            return AllDepartment;
        }

        public static Department GetADepartment(string code)
        {
            return AllDepartment.FirstOrDefault(x => x.Code == code);
        }

        public static Department UpdateDepartment(string code, Department department)
        {
            Department result = new Department();
            foreach (var adepartment in AllDepartment)
            {
                if (code==adepartment.Code)
                {
                    adepartment.Name = department.Name;
                    result = adepartment;
                }
            }
            return result;
        }

        public static Department DeleteDepartment(string code)
        {
            var department = AllDepartment.FirstOrDefault(x=> x.Code == code);
            AllDepartment = AllDepartment.Where(x => x.Code != department.Code).ToList();

            return department;

        }
    }
}