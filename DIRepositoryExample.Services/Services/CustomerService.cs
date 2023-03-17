using System.Collections.Generic;
using System.Linq;
using DIRepositoryExample.Services.Interfaces;
using DIRepositoryExample.Services.Helper;

namespace DIRepositoryExample.Services.Services
{
    public class CustomerService : ICustomer
    {
        List<Customer> ICustomer.GetAll()
        {
            return CustomerHelper.customers;
        }

        public Customer GetById(int id)
        {
            return CustomerHelper.customers.FirstOrDefault(c => c.Id == id);
        }

        public int Create(Customer customer)
        {
            customer.Id = CustomerHelper.nextId++;
            CustomerHelper.customers.Add(customer);
            return customer.Id;
        }

        public int Update(int id, Customer customer)
        {
            Customer existingCustomer = CustomerHelper.customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Locations = customer.Locations;
            }
            return customer.Id;
        }

        public bool Delete(int id)
        {
            Customer customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customer.Locations.Clear();
                CustomerHelper.customers.Remove(customer);
            }
            return false;
        }
    }
}

