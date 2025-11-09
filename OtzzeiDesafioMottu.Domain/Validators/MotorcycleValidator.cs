using FluentValidation;
using OtzzeiDesafioMottu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Validators
{
    public class MotorcycleValidator :AbstractValidator<Motorcycle>
    {
        public MotorcycleValidator()
        {
            RuleFor(x => x.Modelo).NotEmpty().WithMessage("Modelo da moto é obrigatorio.");
            RuleFor(x => x.Ano).NotEmpty().WithMessage("Ano da moto é obrigatorio");
            RuleFor(x => x.Placa).NotEmpty().WithMessage("Placa da moto é obrigatoria");
        }
    }
}
