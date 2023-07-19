using FluentValidation.Results;
using ImportadorCNAB.Shared.Communication.Messages;
using MediatR;

namespace ImportadorCNAB.Shared.Communication.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ValidationResult> EnviarComando<T>(T comando, CancellationToken ct = default) where T : Command
    {
        return await _mediator.Send(comando, ct);
    }
}