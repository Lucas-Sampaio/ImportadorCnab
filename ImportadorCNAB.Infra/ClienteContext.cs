using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Domain.seedWork;
using Microsoft.EntityFrameworkCore;

namespace ImportadorCNAB.Infra;

public class ClienteContext : DbContext, IUnitOfWork
{
    public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<TipoTransacao> TiposTransacoes { get; set; }
    public DbSet<TransacaoPositiva> TiposTransacoesPositivas { get; set; }
    public DbSet<TransacaoNegativa> TiposTransacoesNegativas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //usado so em debug para obter erros mais detalhados
#if DEBUG
        optionsBuilder.EnableDetailedErrors();
#endif

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // pega as configurações das entidades
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .HaveColumnType("varchar(200)");

        base.ConfigureConventions(configurationBuilder);
    }

    public async ValueTask<bool> CommitAsync()
    {
        var sucesso = await base.SaveChangesAsync() > 0;
        return sucesso;
    }
}