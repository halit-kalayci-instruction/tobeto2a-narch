using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable("IndividualCustomers").HasKey(ic => ic.Id);

        builder.Property(ic => ic.Id).HasColumnName("Id").IsRequired();
        builder.Property(ic => ic.NationalityId).HasColumnName("NationalityId");
        builder.Property(ic => ic.CustomerId).HasColumnName("CustomerId");
        builder.Property(ic => ic.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ic => ic.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ic => ic.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: c => c.CustomerId, name: "IndividualCustomer_CustomerID_UK").IsUnique();

        builder.HasOne(c => c.Customer);

        builder.HasQueryFilter(ic => !ic.DeletedDate.HasValue);
    }
}