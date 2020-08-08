using System.Threading.Tasks;
using DLL.Model;
using System.Collections.Generic;
using DLL.Repositories;
using BLL.Request;

namespace BLL.Services
{
    public interface IDepartmentService
    {
        Task<Department> InsertAsync(DepartmentInsertRequestViewModel request);
        Task<List<Department>> GetAllAsync();
        Task<Department> GetAAsync(string code);
        Task<Department> UpdateAsync(string code, Department department);
        Task<Department> DeleteAsync(string code);
        Task<bool> IsCodeExists(string code);
        Task<bool> IsNameExists(string name);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> InsertAsync(DepartmentInsertRequestViewModel request)
        {
            Department aDepartment = new Department();
            aDepartment.Code = request.Code;
            aDepartment.Name = request.Name;
            return await _departmentRepository.InsertAsync(aDepartment);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }
        public async Task<Department> DeleteAsync(string code)
        {
            return await _departmentRepository.DeleteAsync(code);
        }

        public async Task<Department> GetAAsync(string code)
        {

            return await _departmentRepository.GetAAsync(code);
        }


        public async Task<Department> UpdateAsync(string code, Department department)
        {
            return await _departmentRepository.UpdateAsync(code, department);

        }

        public async Task<bool> IsCodeExists(string code)
        {
            var department = await _departmentRepository.FindByCode(code);
            if (department==null)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.FindByName(name);
            if (department == null)
            {
                return true;
            }

            return false;

        }
    }
}
