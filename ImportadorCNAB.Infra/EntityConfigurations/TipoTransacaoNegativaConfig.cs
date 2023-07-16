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

    private static List<TransacaoNegativa> ObterTransacoesIniciais()
    {
        return new List<TransacaoNegativa>()
        {
            new TransacaoNegativa(2,"Boleto",2),
            new TransacaoNegativa(3,"Financiamento",3),
            new TransacaoNegativa(9,"Aluguel",9)
        };
    }
}