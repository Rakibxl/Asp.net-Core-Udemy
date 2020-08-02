using System.Threading.Tasks;
using DLL.Model;
using DLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class StudentController : MainApiController
    {
        private readonly IStudentRepository _StudentRepository;
        public StudentController(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _StudentRepository.GetAllAsync());
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetA(string email)
        {
            return Ok(await _StudentRepository.GetAAsync(email));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Student Student)
        {
            return Ok(await _StudentRepository.InsertAsync(Student));
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> Update(string email, Student Student)
        {
            return Ok(await _StudentRepository.UpdateAsync(email, Student));
        }
        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            return Ok(await _StudentRepository.DeleteAsync(email));
        }


    }

}
