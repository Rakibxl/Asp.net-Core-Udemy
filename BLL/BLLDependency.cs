using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BLL.Services;
using FluentValidation;
using DLL.Model;
using BLL.Request;

namespace BLL
{
    public static class BLLDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IStudentService, StudentService>();

            AllFluentValidationDependency(services);

        }

        private static void AllFluentValidationDependency(IServiceCollection services)
        {
            services.AddTransient<IValidator<DepartmentInsertRequestViewModel>, DepartmentInsertRequestViewModelValidator>();
        }


    }
}
