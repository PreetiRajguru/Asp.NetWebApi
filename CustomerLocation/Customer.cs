using System;

namespace CustomerController
{
    // Customer.cs
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }

        public List<CustomerLocation> Locations { get; set; }
    }

    // CustomerLocation.cs
    public class CustomerLocation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string ZipCode { get; set; }

        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
    }

    /*public class RequestParams
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }*/

}
