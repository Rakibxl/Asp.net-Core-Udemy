using BLL.Services;
using DLL.Model;
using DLL.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Request
{
    public class DepartmentInsertRequestViewModel
    {
        public string Name { get; set; }

        public string Code { get; set; }


    }

    public class DepartmentInsertRequestViewModelValidator : AbstractValidator<DepartmentInsertRequestViewModel>
    {
        private readonly IServiceProvider _serviceProvider;
        public DepartmentInsertRequestViewModelValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleFor(x => x.Code).NotNull().NotEmpty().MinimumLength(3).MinimumLength(10).MustAsync(CodeExists).WithMessage("code already exists");
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(4).MinimumLength(25).MustAsync(NameExists).WithMessage("name already exists");
        }

        private async Task<bool> NameExists(string Name, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return true;
            }

            var requiredService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requiredService.IsNameExists(Name);
        }

        private async Task<bool> CodeExists(string Code, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(Code))
            {
                return true;
            }
            var requiredService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requiredService.IsCodeExists(Code);
        }
    }
}
