using FluentValidation;
using ImportadorCNAB.Shared.Communication.Messages;

namespace ImportadorCNAB.Api.Application.Commands.ArquivoCnabComand;

public class ProcessarArquivoCnabCommand : Command
{
    public ProcessarArquivoCnabCommand(IFormFile file)
    {
        Arquivo = file;
    }
    public IFormFile Arquivo { get; init; }

    public override bool EhValido()
    {
        ValidationResult = new ProcessarArquivoCnabValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class ProcessarArquivoCnabValidation : AbstractValidator<ProcessarArquivoCnabCommand>
    {
        public ProcessarArquivoCnabValidation()
        {
            RuleFor(x => x.Arquivo.Length)
                .GreaterThan(0)
                .WithMessage("O arquivo nao pode ser vazio");

            RuleFor(x => x.Arquivo.FileName)
                .Must(x => x.EndsWith("txt",StringComparison.InvariantCultureIgnoreCase))
                .WithMessage("O arquivo precisa ser txt");
        }
    }
}