using FluentValidation;
using WebApiVylex.Models;

namespace WebApiVylex.Validation
{
    public class AvaliacaoValidator : AbstractValidator<Avaliacao>
    {
        public AvaliacaoValidator()
        {
            RuleFor(avaliacao => avaliacao.Estrelas).InclusiveBetween(1, 5).WithMessage("Entre 1 e 5");

            RuleFor(avaliacao => avaliacao.Comentario).MaximumLength(200)
                .WithMessage("Descrição não pode exceder 200 caracteres.");
            RuleFor(avaliacao => avaliacao.DataHora).NotEmpty().WithMessage("Campo Obrigatorio");

            RuleFor(avaliacao => avaliacao.EstudanteId).NotEmpty().WithMessage("Campo Obrigatorio");

            RuleFor(avaliacao => avaliacao.CursoId).NotEmpty().WithMessage("Campo Obrigatorio");


        }
    }
}
