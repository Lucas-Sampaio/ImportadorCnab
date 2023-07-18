﻿using FluentValidation.Results;
using ImportadorCNAB.Shared.Communication.Messages;

namespace ImportadorCNAB.Shared.Communication.Mediator;

public interface IMediatorHandler
{
    Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
}