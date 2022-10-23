using Insurance.Sample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data.EntityTypeConfigurations
{
    public class VehicleLicenseEntityConfig : EntityTypeConfiguration<VehicleLicense>
    {
        public VehicleLicenseEntityConfig()
        {
            this.HasKey(f => f.Id);

            this.Property(f => f.CustomerId)
                .IsRequired();

            this.Property(f => f.Plate)
                .HasMaxLength(8)
                .IsRequired();
            this.Property(f => f.SerialCode)
                .HasMaxLength(2)
                .IsRequired();
            this.Property(f => f.SerialNo)
                .IsRequired();

            this.HasRequired(f => f.Customer).WithMany(f => f.VehicleLicenses);

            this.ToTable("VehicleLicenses");
        }
    }
}
