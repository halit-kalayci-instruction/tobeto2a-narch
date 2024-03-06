using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CustomerNo).HasColumnName("CustomerNo");
        builder.Property(c => c.UserId).HasColumnName("UserId");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(indexExpression: c => c.UserId, name: "Customer_UserID_UK").IsUnique();
        builder.HasOne(i => i.User);
        builder.HasOne(i => i.IndividualCustomer);
        builder.HasOne(i => i.CorporateCustomer);
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}