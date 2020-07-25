using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DLL.Repositories;

namespace DLL
{
    public static class DLLDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DLL.DBContext.ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            //repository dependency

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        }
    }
}
