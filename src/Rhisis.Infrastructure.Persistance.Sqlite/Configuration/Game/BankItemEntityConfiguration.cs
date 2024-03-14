using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rhisis.Infrastructure.Persistance.Entities;

namespace Rhisis.Infrastructure.Persistance.Sqlite.Configuration.Game;

public sealed class BankItemEntityConfiguration : IEntityTypeConfiguration<BankItemEntity>
{
    public void Configure(EntityTypeBuilder<BankItemEntity> builder)
    {
        builder.HasKey(x => new { x.BankId, x.Slot });
        builder.HasIndex(x => new { x.BankId, x.Slot }).IsUnique();
        builder.Property(x => x.BankId).IsRequired();
        builder.Property(x => x.ItemId).IsRequired();
        builder.Property(x => x.Slot).IsRequired();
        builder.Property(x => x.Quantity);

        builder.HasOne(x => x.Bank)
            .WithOne()
            .HasForeignKey<BankItemEntity>(x => x.BankId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Bank)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.BankId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
