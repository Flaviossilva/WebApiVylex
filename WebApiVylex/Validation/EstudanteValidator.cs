using FluentValidation;
using WebApiVylex.Models;

namespace WebApiVylex.Validation
{
    public class EstudanteValidator : AbstractValidator<Estudante>
    {
        public EstudanteValidator()
        {
            RuleFor(estudante => estudante.Nome).NotEmpty().WithMessage("Campo Obrigatorio")
    .MaximumLength(80).WithMessage("Nome não pode exceder 80 caracteres.");

            RuleFor(estudante => estudante.Email).NotEmpty().WithMessage("Email Obrigatorio.")
            .EmailAddress().WithMessage("insira um email valido.");
        }
    }
}
