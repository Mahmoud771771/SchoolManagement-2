using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;

        #endregion
        #region Constuctors
        public EditStudentValidator(IStudentService studentService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            _studentService = studentService;
        }
        #endregion
        #region  functions
        public void ApplyValidationRules()
        {
            RuleFor(e => e.NameAr)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
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
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(key, model.Id))
                .WithMessage("Name is Exist");
        }
        #endregion

    }
}
