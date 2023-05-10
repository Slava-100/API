using FluentValidation;
using technoTest.API.Models.User.Request;

namespace TechnoTest.API.Validation
{
    public class UserValidator : AbstractValidator<UserAddRequestDto>
    {
        public UserValidator()
        {
            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password is emty!");
            
            RuleFor(request => request.Login)
                .NotEmpty().WithMessage("Login is emty!");
        }
    }
}
