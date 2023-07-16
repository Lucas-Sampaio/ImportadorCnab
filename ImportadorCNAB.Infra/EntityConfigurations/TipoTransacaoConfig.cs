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
    }
}