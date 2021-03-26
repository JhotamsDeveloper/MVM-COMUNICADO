using CORE.DTOs;
using FluentValidation;

namespace API.FluentValidation
{
    public class ValidateUserSystem : AbstractValidator<UserSystemDto>
    {
        public ValidateUserSystem()
        {
            RuleFor(x => x.NameUser).NotEmpty().WithMessage("El nombre no puede ir vacio");
            RuleFor(x => x.TypeDocument).NotEmpty();
            RuleFor(x => x.Document).NotEmpty().Length(4, 15);
            RuleFor(x => x.Phone).Length(7, 15);
            RuleFor(x => x.Email).EmailAddress().WithMessage("No cumple el formato de Email");
            RuleFor(x => x.AddressUser).NotEmpty();
        }
    }
}
