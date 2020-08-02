using System.Threading.Tasks;
using DLL.Model;
using System.Collections.Generic;
using DLL.Repositories;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<Student> InsertAsync(Student Student);
        Task<List<Student>> GetAllAsync();
        Task<Student> GetAAsync(string email);
        Task<Student> UpdateAsync(string email, Student Student);
        Task<Student> DeleteAsync(string email);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;
        public StudentService(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }

        public async Task<Student> InsertAsync(Student Student)
        {
            return await _StudentRepository.InsertAsync(Student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _StudentRepository.GetAllAsync();
        }
        public async Task<Student> DeleteAsync(string code)
        {
            return await _StudentRepository.DeleteAsync(code);
        }

        public async Task<Student> GetAAsync(string code)
        {

            return await _StudentRepository.GetAAsync(code);
        }

        public async Task<Student> UpdateAsync(string code, Student Student)
        {
            return await _StudentRepository.UpdateAsync(code, Student);

        }

    }
}
