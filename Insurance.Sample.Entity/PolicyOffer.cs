using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity
{
    public class PolicyOffer
    {
        public int Id { get; set; }
        public long ReferenceKey { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOnUtc { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual Company Company { get; set; }
    }
}
