using ImportadorCNAB.Domain.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportadorCNAB.Infra.EntityConfigurations;

public class TipoTransacaoNegativaConfig : IEntityTypeConfiguration<TransacaoNegativa>
{
    public void Configure(EntityTypeBuilder<TransacaoNegativa> builder)
    {
         builder.HasData(ObterTransacoesIniciais());
    }

    private static List<TipoTransacao> ObterTransacoesIniciais()
    {
        return new List<TipoTransacao>()
        {
            new TransacaoNegativa(2,"Boleto"),
            new TransacaoNegativa(3,"Financiamento"),
            new TransacaoNegativa(9,"Aluguel")
        };
    }
}