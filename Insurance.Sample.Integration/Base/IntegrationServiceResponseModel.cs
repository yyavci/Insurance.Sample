using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Insurance.Sample.Entity.Enums;

namespace Insurance.Sample.Integration.Base
{
    public class IntegrationServiceResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
