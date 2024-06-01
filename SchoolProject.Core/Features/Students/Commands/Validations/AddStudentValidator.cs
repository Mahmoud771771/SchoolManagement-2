using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;


        #endregion
        #region Constuctors
        public AddStudentValidator(IStudentService studentService
            , IDepartmentService _departmentService
            , IStringLocalizer<SharedResources> stringLocalizer)
        {
            //    ApplyValidationRules();
            //    ApplyCustomValidationRules();
            //    _studentService = studentService;
            //    _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region  functions
        public void ApplyValidationRules()
        {
            RuleFor(e => e.NameAr)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("{PropertyName} must not be Null")
                .MaximumLength(20).WithMessage("{PropertyName} must Length is 20");

            RuleFor(e => e.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be Null")
                .MaximumLength(20).WithMessage("{PropertyName} must Length is 20");


        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(e => e.NameAr)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                .WithMessage("Name is Exist");
            When(p => p.DepartmentId != null, () =>
            {
                RuleFor(e => e.DepartmentId)
                    .MustAsync(async (key, CancellationToken) => !await _departmentService.IsDepartmentExist(key.Value))
                    .WithMessage("DepartmentId is not exist");


            });

        }
        #endregion

    }
}
