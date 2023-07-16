using ImportadorCNAB.Domain.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportadorCNAB.Infra.EntityConfigurations;

public class TipoTransacaoPositivaConfig : IEntityTypeConfiguration<TransacaoPositiva>
{
    public void Configure(EntityTypeBuilder<TransacaoPositiva> builder)
    {
        builder.HasData(ObterTransacoesIniciais());
    }

    private static List<TipoTransacao> ObterTransacoesIniciais()
    {
        return new List<TipoTransacao>()
        {
            new TransacaoPositiva(1,"Debito"),
            new TransacaoPositiva(4,"Crédito"),
            new TransacaoPositiva(5,"Recebimento Empréstimo"),
            new TransacaoPositiva(6,"Vendas"),
            new TransacaoPositiva(7,"Recebimento TED"),
            new TransacaoPositiva(8,"Recebimento DOC"),
        };
    }
}