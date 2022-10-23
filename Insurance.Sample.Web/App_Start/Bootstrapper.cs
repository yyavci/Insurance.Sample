using Autofac;
using Autofac.Integration.Mvc;
using Insurance.Sample.Data;
using Insurance.Sample.Integration;
using Insurance.Sample.Integration.Base;
using Insurance.Sample.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Sample.Web
{
    public static class Bootstrapper
    {
        public static IContainer SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();

            builder.RegisterType<InsuranceContext>().As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));

            
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<IntegrationService>().As<IIntegrationService>();
            builder.RegisterType<VehicleLicenseService>().As<IVehicleLicenseService>();
            builder.RegisterType<PolicyService>().As<IPolicyService>();


            builder.RegisterType<ACompanyIntegrationService>().As<ICompanyIntegrationService>();
            builder.RegisterType<BCompanyIntegrationService>().As<ICompanyIntegrationService>();
            builder.RegisterType<CCompanyIntegrationService>().As<ICompanyIntegrationService>();
            //builder.RegisterType<DCompanyIntegrationService>().As<ICompanyIntegrationService>();
            //builder.RegisterType<ECompanyIntegrationService>().As<ICompanyIntegrationService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}