using Insurance.Sample.Data.EntityTypeConfigurations;
using Insurance.Sample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data
{
    public class InsuranceContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PolicyOffer> PolicyOffers { get; set; }
        public DbSet<VehicleLicense> VehicleLicenses { get; set; }

        public InsuranceContext() : base("name=InsuranceConnStr")
        {
            Database.SetInitializer(new InsuranceDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CustomerEntityConfig());
            modelBuilder.Configurations.Add(new CompanyEntityConfig());
            modelBuilder.Configurations.Add(new PolicyOfferEntityConfig());
            modelBuilder.Configurations.Add(new VehicleLicenseEntityConfig());

        }


    }
}
