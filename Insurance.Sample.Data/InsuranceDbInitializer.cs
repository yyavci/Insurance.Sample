using Insurance.Sample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data
{
    public class InsuranceDbInitializer : CreateDatabaseIfNotExists<InsuranceContext>
    {
        public InsuranceDbInitializer()
        {
        }
        protected override void Seed(InsuranceContext context)
        {
            IList<Company> companies = new List<Company>();
            //SampleProject.Domain.MyNewTestClass, MyTestProject
            companies.Add(new Company()
            {
                Name = "A Firması",
                InsuranceType = Enums.InsuranceType.Vehicle,
                IsActive = true,
                LogoUrl = "https://image.shutterstock.com/image-vector/vector-design-elements-your-company-600w-709133980.jpg",
                Assembly = "Insurance.Sample.Integration.ACompanyIntegrationService"
            });
            companies.Add(new Company()
            {
                Name = "B Firması",
                InsuranceType = Enums.InsuranceType.Vehicle,
                IsActive = true,
                LogoUrl = "https://image.shutterstock.com/image-vector/c-letter-logo-concept-creative-600w-1503385775.jpg",
                Assembly = "Insurance.Sample.Integration.BCompanyIntegrationService"
            });
            companies.Add(new Company()
            {
                Name = "C Firması",
                InsuranceType = Enums.InsuranceType.Vehicle,
                IsActive = true,
                LogoUrl = "https://image.shutterstock.com/image-vector/play-logo-technology-design-colorful-600w-1437505109.jpg",
                Assembly = "Insurance.Sample.Integration.CCompanyIntegrationService"
            });
            companies.Add(new Company()
            {
                Name = "D Firması",
                InsuranceType = Enums.InsuranceType.Life,
                IsActive = true,
                LogoUrl = "https://image.shutterstock.com/image-vector/abstract-latter-n-illustrations-vector-600w-1552546865.jpg",
                Assembly = "Insurance.Sample.Integration.DCompanyIntegrationService"
            });

            context.Companies.AddRange(companies);

            base.Seed(context);

        }
    }
}
