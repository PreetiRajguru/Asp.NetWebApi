using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRepositoryExample.Services.Services
{
    public class Customer
    {
        public Customer()
        {
            this.Locations = new List<CustomerLocation>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<CustomerLocation> Locations { get; set; }
    }
}
