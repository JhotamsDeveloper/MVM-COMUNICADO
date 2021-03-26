using CORE.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.FluentValidation
{
    public class ValidateCompanyStatement : AbstractValidator<CompanyStatement>
    {
        public ValidateCompanyStatement()
        {
            RuleFor(x => x.NameFile).NotEmpty().WithMessage("No puede estar vacio");
        }
    }
}
