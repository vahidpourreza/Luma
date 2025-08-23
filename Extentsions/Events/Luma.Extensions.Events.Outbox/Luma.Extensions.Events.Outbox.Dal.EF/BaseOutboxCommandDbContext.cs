using Luma.Extensions.Events.Abstractions;
using Luma.Extensions.Events.Outbox.Dal.EF.Configs;
using Luma.Extensions.Events.Outbox.Dal.EF.Interceptors;
using Luma.Infra.Data.Sql.Commands;

namespace Luma.Extensions.Events.Outbox.Dal.EF;

public abstract class BaseOutboxCommandDbContext : BaseCommandDbContext
{
    public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }

    public BaseOutboxCommandDbContext(DbContextOptions options) : base(options)
    {

    }

    protected BaseOutboxCommandDbContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors(new AddOutBoxEventItemInterceptor());
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new OutBoxEventItemConfig());
    }


}
