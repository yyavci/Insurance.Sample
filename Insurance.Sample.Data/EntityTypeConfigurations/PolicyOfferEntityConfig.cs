using Insurance.Sample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data.EntityTypeConfigurations
{
    public class PolicyOfferEntityConfig : EntityTypeConfiguration<PolicyOffer>
    {
        public PolicyOfferEntityConfig()
        {
            this.HasKey(f => f.Id);

            this.Property(f => f.CompanyId)
                .IsRequired();
            this.Property(f => f.CustomerId)
                .IsRequired();
            this.Property(f => f.Price)
                .IsRequired();
            this.Property(f => f.ReferenceKey)
                .IsRequired();
            this.Property(f => f.CreatedOnUtc)
                .IsRequired();

            this.HasRequired(f => f.Customer).WithMany(f => f.PolicyOffers).HasForeignKey(f => f.CustomerId);
            this.HasRequired(f => f.Company).WithMany(f => f.PolicyOffers).HasForeignKey(f => f.CompanyId);


            this.ToTable("PolicyOffers");
        }
    }
}
