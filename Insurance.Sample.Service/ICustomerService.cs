using Insurance.Sample.Entity;
using Insurance.Sample.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Service
{
    public interface ICustomerService
    {
        ServiceResponse<int> AddNewCustomer(string tckn);
        ServiceResponse<int> GetCustomerIdWithVehicleLicense(string tckn, string plate);
        ServiceResponse<bool> IsCustomerExists(string tckn);
        ServiceResponse<VehicleLicenseModel> GetCustomerVehicleLicense(int customerId, string plate);
    }
}
