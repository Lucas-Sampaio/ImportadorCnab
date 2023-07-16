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
            new TransacaoPositiva(1,"Debito",1),
            new TransacaoPositiva(4,"Crédito",4),
            new TransacaoPositiva(5,"Recebimento Empréstimo",5),
            new TransacaoPositiva(6,"Vendas",6),
            new TransacaoPositiva(7,"Recebimento TED",7),
            new TransacaoPositiva(8,"Recebimento DOC",8),
        };
    }
}