using ImportadorCNAB.Domain.seedWork;

namespace ImportadorCNAB.Domain.ClienteAggregate;

public interface IClienteRepository : IRepository<Cliente>
{
    ValueTask AdicionarClientesAsync(List<Cliente> clientes, CancellationToken cancellation);

    ValueTask AtualizarClientesAsync(List<Cliente> clientes, CancellationToken cancellation);

    /// <summary>
    /// Obtem cliente pelo id
    /// </summary>
    /// <param name="clienteId">id do cliente</param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    ValueTask<Cliente?> ObterCliente(int clienteId, CancellationToken cancellation);

    /// <summary>
    /// Obtem todos os clientes importados pesquisando pelo nome da loja
    /// </summary>
    /// <param name="nomesLoja">nome da loja</param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    ValueTask<List<Cliente>> ObterClientes(IEnumerable<string> nomesLoja, CancellationToken cancellation);

    /// <summary>
    /// Obtem o nome de todas lojas
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns>retorna uma lista de tupla com o id e nome da loja</returns>
    ValueTask<List<(int id, string nomeLoja)>> ObterLojas(CancellationToken cancellation);

    /// <summary>
    /// Obtem os tipos transacoes pesquisando pelos codigos informados
    /// </summary>
    /// <param name="codigos">codigos das transacoes</param>
    /// <param name="cancellation"></param>
    /// <returns>Retorna os tipo transacoes</returns>
    ValueTask<List<TipoTransacao>> ObterTiposTransacoes(IEnumerable<int> codigos, CancellationToken cancellation);
}