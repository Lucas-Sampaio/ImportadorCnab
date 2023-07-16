using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportadorCNAB.Infra.EntityConfigurations;

public class TipoTransacaoConfig : IEntityTypeConfiguration<TipoTransacao>
{
    public void Configure(EntityTypeBuilder<TipoTransacao> builder)
    {
        builder.ToTable("TipoTransacao");

        builder.HasKey(c => c.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Descricao).IsRequired();
        builder.Property(x => x.Codigo).IsRequired();

        builder.Property(x => x.Natureza)
            .HasConversion(
                v => v.ToString(),
                v => (ENatureza)Enum.Parse(typeof(ENatureza), v)
            );

        builder.HasDiscriminator(x => x.Natureza)
            .HasValue<TransacaoPositiva>(ENatureza.Entrada);

        builder.HasDiscriminator(x => x.Natureza)
            .HasValue<TransacaoNegativa>(ENatureza.Saida);

        builder.HasData(ObterTransacoesIniciais());
    }

    private static List<TipoTransacao> ObterTransacoesIniciais()
    {
        return new List<TipoTransacao>()
        {
            new TransacaoPositiva(1,"Debito"),
            new TransacaoNegativa(2,"Boleto"),
            new TransacaoNegativa(3,"Financiamento"),
            new TransacaoPositiva(4,"Crédito"),
            new TransacaoPositiva(5,"Recebimento Empréstimo"),
            new TransacaoPositiva(6,"Vendas"),
            new TransacaoPositiva(7,"Recebimento TED"),
            new TransacaoPositiva(8,"Recebimento DOC"),
            new TransacaoNegativa(9,"Aluguel"),
        };
    }
}