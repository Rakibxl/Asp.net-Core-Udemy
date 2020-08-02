using System.Threading.Tasks;
using API.Controllers;
using DLL.Model;
using DLL.Repositories;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class DepartmentController : MainApiController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            return Ok(await _departmentService.GetAllAsync());
        }
        [HttpGet("{code}")]
        public async Task<IActionResult> GetA(string code)
        {
            return Ok(await _departmentService.GetAAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Department department)
        {
            return Ok(await _departmentService.InsertAsync(department));
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, Department department)
        {
            return Ok(await _departmentService.UpdateAsync(code,department));
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok(await _departmentService.DeleteAsync(code));
        }

    }


}