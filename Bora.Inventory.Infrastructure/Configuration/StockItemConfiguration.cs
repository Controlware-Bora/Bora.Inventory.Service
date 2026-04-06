using Bora.Inventory.Domain.Aggregates.StockItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bora.Inventory.Infrastructure.Configuration;

public class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
{
    public void Configure(EntityTypeBuilder<StockItem> builder)
    {
        builder.ToTable("StockItem");
        builder.HasKey(si => si.Id);
        builder.Property(si => si.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(si => si.Quantity).IsRequired();
        builder.Property(si => si.Name).IsRequired().HasMaxLength(50);
    }
}