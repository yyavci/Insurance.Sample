using Insurance.Sample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data.EntityTypeConfigurations
{
    public class CustomerEntityConfig : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityConfig()
        {
            this.HasKey(f => f.Id);

            this.Property(f => f.Tckn)
                .IsRequired()
                .HasMaxLength(11);

            this.ToTable("Customers");

        }
    }
}
