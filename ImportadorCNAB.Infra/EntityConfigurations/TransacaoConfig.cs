using ImportadorCNAB.Domain.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportadorCNAB.Infra.EntityConfigurations;

public class TransacaoConfig : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.ToTable("Transacao");

        builder.HasKey(c => c.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.CartaoUtilizadoNumero).IsRequired();
        builder.Property(x => x.Data).IsRequired();
        builder.Property(x => x.Valor).IsRequired();

        builder.HasOne(x => x.TipoTransacao).WithMany();
    }
}