namespace ImportadorCNAB.Domain.seedWork;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Confirma as transações
    /// </summary>
    /// <returns></returns>
    ValueTask<bool> CommitAsync(CancellationToken cancellation);
}