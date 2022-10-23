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
    public class VehicleLicenseService : IVehicleLicenseService
    {
        private readonly IRepository<VehicleLicense> vehicleLicenseRepository;

        public VehicleLicenseService(
            IRepository<VehicleLicense> vehicleLicenseRepository
            )
        {
            this.vehicleLicenseRepository = vehicleLicenseRepository;
        }

        public ServiceResponse<int> AddNewVehicleLicense(VehicleLicenseModel model)
        {
            var response = new ServiceResponse<int>();

            var vehicleLicense = new VehicleLicense()
            {
                CustomerId = model.CustomerId,
                Plate = model.Plate,
                SerialCode = model.SerialCode,
                SerialNo = model.SerialNo
            };
            vehicleLicenseRepository.Add(vehicleLicense);

            response.Data = vehicleLicense.Id;

            return response;
        }
    }
}
