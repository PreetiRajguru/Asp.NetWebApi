using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIRepositoryExample.Services.Services;

namespace DIRepositoryExample.Services.Helper
{
    public static class CustomerHelper
    {
        public static List<Customer> customers = new List<Customer>();
        public static int nextId = 1;
    }
}
