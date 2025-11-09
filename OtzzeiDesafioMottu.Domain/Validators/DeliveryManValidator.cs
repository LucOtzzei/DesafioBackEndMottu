using FluentValidation;
using OtzzeiDesafioMottu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Validators
{
    public class DeliveryManValidator : AbstractValidator<DeliveryMan>
    {
        public DeliveryManValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome deve ser preenchido.");
            RuleFor(x => x.Cnpj).NotEmpty().Length(14).WithMessage("CNPJ deve ter  14 digitos(apenas numeros).");
            RuleFor(x => x.CnhNumber).NotEmpty().WithMessage("CNH deve ser preenchida");
            RuleFor(x => x.CnhType).IsInEnum().WithMessage("Tipo de CNH invalido");
        }
    }
}
