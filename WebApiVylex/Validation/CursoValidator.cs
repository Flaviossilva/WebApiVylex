using FluentValidation;
using WebApiVylex.Models;

namespace WebApiVylex.Validation
{
    public class CursoValidator : AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(curso => curso.Nome).NotEmpty().WithMessage("Campo Obrigatorio")
                .MaximumLength(80).WithMessage("Nome não pode exceder 80 caracteres.");

            RuleFor(curso => curso.Descricao).NotEmpty().WithMessage("Campo Obrigatorio")
     .MaximumLength(200).WithMessage("Descrição não pode exceder 200 caracteres.");

        }
    }
}
