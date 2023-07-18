using FluentValidation.Results;
using ImportadorCNAB.Shared.Communication.Mediator;

namespace ImportadorCNAB.Shared.Communication.Messages;

public class CommandHandler
{
    protected ValidationResult ValidationResult;
    protected readonly IMediatorHandler MediatorHandler;

    protected CommandHandler(IMediatorHandler mediatorHandler)
    {
        MediatorHandler = mediatorHandler;
        ValidationResult = new ValidationResult();
    }

    protected void AdicionarErro(string mensagem)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
    }
}