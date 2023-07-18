using ImportadorCNAB.Domain.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportadorCNAB.Infra.EntityConfigurations;

public class ClienteConfig : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");

        builder.HasKey(c => c.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.NomeLoja).IsRequired();
        builder.OwnsOne(x => x.Cpf, e =>
        {
            e.Property(x => x.Numero).IsRequired().HasMaxLength(11);
        });
        builder.HasMany(x => x.Transacoes).WithOne();
    }
}