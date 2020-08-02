using DLL.DBContext;
using DLL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> InsertAsync(Student Student);
        Task<List<Student>> GetAllAsync();
        Task<Student> GetAAsync(string email);
        Task<Student> UpdateAsync(string email, Student Student);
        Task<Student> DeleteAsync(string email);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Student> InsertAsync(Student Student)
        {
          await  _context.Students.AddAsync(Student);
           await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();

        }
        public async Task<Student> DeleteAsync(string email)
        {

            var Student = await _context.Students.FirstOrDefaultAsync(x => x.Email == email);
            _context.Students.Remove(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<Student> GetAAsync(string email)
        {

            var Student = await _context.Students.FirstOrDefaultAsync(x => x.Email == email);
            return Student;

        }


        public async Task<Student> UpdateAsync(string email, Student Student)
        {

            var findStudent = await _context.Students.FirstOrDefaultAsync(x => x.Email == email);
            findStudent.Name = Student.Name;
            _context.Students.Update(findStudent);
            await _context.SaveChangesAsync();
            return Student;

        }


    }
}
