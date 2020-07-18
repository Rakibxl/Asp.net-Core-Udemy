using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get all student");
        }
        [HttpGet(template: "{code}")]
        public IActionResult GetA(string code)
        {
            return Ok("get this" + code + "departmentdata");
        }

        [HttpPost(template: "{code}")]
        public IActionResult Insert(string code)
        {
            return Ok("insert this" + code + "department data");
        }

        [HttpPut(template: "{code}")]
        public IActionResult Update(string code)
        {
            return Ok("Update this" + code + "department data");
        }
        [HttpDelete(template: "{code}")]
        public IActionResult Delete(string code)
        {
            return Ok("Deleted department" + code + "succesfully");
        }

    }
}