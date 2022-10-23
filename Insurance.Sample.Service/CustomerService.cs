using Insurance.Sample.Data;
using Insurance.Sample.Entity;
using Insurance.Sample.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public ServiceResponse<bool> IsCustomerExists(string tckn)
        {
            if (string.IsNullOrWhiteSpace(tckn))
                throw new ArgumentNullException("TCKN boş olamaz!");

            var response = new ServiceResponse<bool>();

            var customer = customerRepository.GetAll().FirstOrDefault(f => f.Tckn == tckn);

            response.Data = customer != null;

            return response;
        }
        
        public ServiceResponse<int> AddNewCustomer(string tckn)
        {
            if (string.IsNullOrWhiteSpace(tckn))
                throw new ArgumentNullException("TCKN boş olamaz!");

            var response = new ServiceResponse<int>();

            var customer = new Customer()
            {
                Tckn = tckn
            };
            customerRepository.Add(customer);

            response.Data = customer.Id;

            return response;
        }

        public ServiceResponse<int> GetCustomerIdWithVehicleLicense(string tckn, string plate)
        {
            if (string.IsNullOrWhiteSpace(tckn))
                throw new ArgumentNullException("TCKN boş olamaz!");

            if (string.IsNullOrWhiteSpace(plate))
                throw new ArgumentNullException("Plaka boş olamaz!");

            var response = new ServiceResponse<int>();

            var customer = customerRepository.GetAll().Where(f => f.Tckn.Equals(tckn)).FirstOrDefault();

            if (customer == null)
                return response;

            var license = customer.VehicleLicenses.FirstOrDefault(f => f.Plate.Equals(plate));

            if(license == null)
                return response;

            response.Data = customer.Id;

            return response;
        }


        public ServiceResponse<VehicleLicenseModel> GetCustomerVehicleLicense(int customerId,string plate)
        {
            var response = new ServiceResponse<VehicleLicenseModel>();

            var customer = customerRepository.Get(customerId);

            if (customer == null)
                return response;

            var license = customer.VehicleLicenses.FirstOrDefault(f => f.Plate.Equals(plate.Trim().ToUpper()));

            if (license == null)
                return response;

            response.Data = new VehicleLicenseModel()
            {
                CustomerId = customerId,
                Id = license.Id,
                Plate = plate,
                SerialCode = license.SerialCode,
                SerialNo = license.SerialNo
            };

            return response;
        }

    }
}
