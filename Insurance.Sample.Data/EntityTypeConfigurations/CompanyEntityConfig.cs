using Insurance.Sample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data.EntityTypeConfigurations
{
    public class CompanyEntityConfig : EntityTypeConfiguration<Company>
    {
        public CompanyEntityConfig()
        {
            this.HasKey(f => f.Id);

            this.Property(f => f.Assembly)
                .HasMaxLength(512)
                .IsRequired();
            this.Property(f => f.InsuranceType)
                .IsRequired();
            this.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(64);
            this.Property(f => f.LogoUrl)
                .IsOptional()
                .HasMaxLength(1024);
            this.Property(f => f.IsActive)
                .IsRequired();

            this.ToTable("Companies");
        }
    }
}
