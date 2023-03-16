using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRepositoryExample.Services.Services
{

    public class Customer
    {
        //public int? Id { get; set; }
        public Customer()
        {
            this.Locations = new List<CustomerLocations>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }
        [Required]
        public List<CustomerLocations> Locations { get; set; }
    }
}
