using FluentValidation;
using HRMS.WebApi.Models;

namespace HRMS.WebApi.Validators
{
    public class DepartmentValidator : AbstractValidator<DepartmentViewModel>
    {
        public DepartmentValidator()
        {
            string msg = "{PropertyName} must be specified";

            RuleFor(d => d.DepartmentName).NotEmpty().WithMessage(msg);
        }
    }
}
