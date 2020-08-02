using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BLL.Services;

namespace BLL
{
    public static class BLLDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IStudentService, StudentService>();

        }


    }
}
