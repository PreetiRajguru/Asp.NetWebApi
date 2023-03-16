using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRepositoryExample.Services.Dtos
{
    public class CustomerLocationDto
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public int CustomerId { get; set; }
    }
}
