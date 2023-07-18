using FluentValidation.Results;
using ImportadorCNAB.Api.Application.Commands.ArquivoCnabComand;
using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Infra.Repositories;
using ImportadorCNAB.Shared.Communication.Mediator;
using MediatR;

namespace ImportadorCNAB.Api.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        //mediator
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        //commands
        services.AddScoped<IRequestHandler<ProcessarArquivoCnabCommand, ValidationResult>, ArquivoCnabCommandHandler>();

        //services.AddScoped<IRequestHandler<AtualizarPessoaCommand, ValidationResult>, PessoaCommandHandler>();
        //services.AddScoped<IRequestHandler<AdicionarEnderecoPessoaCommand, ValidationResult>, EnderecoPessoaCommandHandler>();
        //services.AddScoped<IRequestHandler<AtualizarEnderecoPessoaCommand, ValidationResult>, EnderecoPessoaCommandHandler>();
        //services.AddScoped<IRequestHandler<RemoverEnderecoPessoaCommand, ValidationResult>, EnderecoPessoaCommandHandler>();

        ////events
        //services.AddScoped<INotificationHandler<PessoaAdicionadaEvent>, PessoaEventHandler>();
        //services.AddScoped<INotificationHandler<PessoaAtualizadaEvent>, PessoaEventHandler>();

        ////queries
        //services.AddScoped<IPessoaQuery, PessoaQuery>();


        services.AddScoped<IClienteRepository, ClienteRepository>();
    }
}

