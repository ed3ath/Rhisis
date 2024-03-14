using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rhisis.Infrastructure.Persistance.Entities;

namespace Rhisis.Infrastructure.Persistance.Sqlite.Configuration.Game;

public sealed class BankEntityConfiguration : IEntityTypeConfiguration<BankEntity>
{
    public void Configure(EntityTypeBuilder<BankEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.PlayerId).IsRequired();
        builder.Property(x => x.PlayerSlot).IsRequired();
        builder.Property(x => x.Gold);        
        builder.HasIndex(x => x.PlayerId).IsUnique();
    }
}
