namespace ImportadorCNAB.Domain.seedWork;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Confirma as transações
    /// </summary>
    /// <returns></returns>
    Task<bool> CommitAsync();
}