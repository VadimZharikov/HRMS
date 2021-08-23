using FluentValidation;
using HRMS.WebApi.Models;

namespace HRMS.WebApi.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeValidator()
        {
            string msg = "{PropertyName} must be specified";

            RuleFor(e => e.Name).NotEmpty().WithMessage(msg);
            RuleFor(e => e.Surname).NotEmpty().WithMessage(msg);
            RuleFor(e => e.Sex).NotEmpty().WithMessage(msg);
            RuleFor(e => e.Age).NotEmpty().WithMessage(msg);
            RuleFor(e => e.Position).NotEmpty().WithMessage(msg);
            RuleFor(e => e.Phone).NotEmpty().WithMessage(msg);
            RuleFor(e => e.DepartmentId).NotEmpty().WithMessage(msg);
        }
    }
}
