using System.Collections.Generic;
using DIRepositoryExample.Services.Services;

namespace DIRepositoryExample.Services.Interfaces
{
    public interface ICustomer
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        int Create(Customer customer);
        int Update(int id, Customer customer);
        void Delete(int id);
    }
}
